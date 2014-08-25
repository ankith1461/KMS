using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using DataAccessLayer;


    namespace BusinessLayer
    {
       
        public class FileUploads
        {
            public Object ValidateUpload(HttpFileCollection PostedFile,string server)
            {
                string msg = "";
                for (int i = 0; i < PostedFile.Count; i++)
                {
                    
                    
                    if (PostedFile[i].ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(PostedFile[i].FileName);
                        PostedFile[i].SaveAs(server + FileName);

                       
                        string extension = FileName.Substring(FileName.LastIndexOf(".") + 1);

                        ////////////////////////08/01/14------------------------------
                        string extractPath = server;

                      
                        int no_Of_File = 0;
                        string[] allowdFile = { ".pdf", ".txt", "text", ".doc", ".rtf", ".ppt", "ppt", "pptx", ".jpg", ".bmp", ".rar", ".zip", ".xls", ".xlsx", ".docx" };
                        
                        string FileExt = "." + extension;
                      
                        bool isValidFile = allowdFile.Contains(FileExt);
                        int sizeFlag = 0;
                        if (!isValidFile)
                        {
                           
                            msg = "Please upload only rtf, doc, xls, ppt, pdf, jpg, bmp, zip, rar and txt. ";
                            return msg;
                           
  
                        }
                        else if (PostedFile[i].ContentLength > 10485760)//10485760 byte = 10MB
                        {
                            sizeFlag = 1;
                           msg = "size>10mb";
                           return msg;
                           
                        }

                        else if (FileExt.Equals(".zip"))
                        {
                            bool validZip = true;
                            int zipHasDirectoryFlag = 0;
                            using (var zip = ZipFile.Read(PostedFile[i].FileName))
                            {
                                int totalEntries = zip.Entries.Count;
                                foreach (ZipEntry zz in zip.Entries)
                                {
                                   
                                    if (zz.IsDirectory == true)
                                    {
                                        zipHasDirectoryFlag = 1;
                                        break;
                                    }
                                    else
                                    { 
                                        validZip = allowdFile.Contains(zz.FileName.Substring(zz.FileName.LastIndexOf(".")));
                                        if (validZip == false)
                                            break;
                                        else
                                            no_Of_File++;
                                    }
                                           
                                }

                                if (validZip == false)
                                {
                                    msg = "zip contain unsupported file";
                                
                                    return msg;
                                }
                                else if (zipHasDirectoryFlag == 1)
                                {
                                    msg = "zip contain subdirectory cant upload  file";
                                    return msg;
                                  ;
                                }
                                else if (no_Of_File > 3)
                                {
                                    msg = "u cannot upload more than3 file";
                                    return msg;
                                   
                                }
                           

                                else
                                {
                                    byte[] binary1 = new byte[PostedFile[i].ContentLength];
                                    PostedFile[i].InputStream.Read(binary1, 0, PostedFile[i].ContentLength);
                                    BusinessUserPublishedEdit.BusinessUserUploadFiles(FileName, binary1, extension);


                                    string fname = PostedFile[i].FileName.Substring(PostedFile[i].FileName.LastIndexOf("\\") + 1, PostedFile[i].FileName.LastIndexOf(".") - (PostedFile[i].FileName.LastIndexOf("\\")) - 1);

                                    System.Windows.Forms.MessageBox.Show("fname is " + fname);
                                    string path = Path.Combine(extractPath, fname);
                                    System.Windows.Forms.MessageBox.Show(path + " hi");
                                    Directory.CreateDirectory(path);
                                    zip.ExtractAll(path, ExtractExistingFileAction.DoNotOverwrite);
                                    foreach (ZipEntry zz in zip.Entries)
                                    {
                                        System.Windows.Forms.MessageBox.Show(path + "\\" + zz.FileName);

                                        byte[] binary = File.ReadAllBytes(path + "\\" + zz.FileName);

                                        //  PostedFile.InputStream.Read(binary, 0, PostedFile.ContentLength);
                                        BusinessUserPublishedEdit.BusinessUserUploadFiles(zz.FileName, binary, zz.FileName.Substring(zz.FileName.LastIndexOf(".") + 1));

                                    }
                                    msg = "zip documents uploaded with content";
;                                   return msg;

                                   

                                }
                                
                            }
                        }
                        else
                        {
                            byte[] binary = new byte[PostedFile[i].ContentLength];
                            PostedFile[i].InputStream.Read(binary, 0, PostedFile[i].ContentLength);
                            BusinessUserPublishedEdit.BusinessUserUploadFiles(FileName, binary, extension);
                            msg = "normal documents uploaded";
                            return msg;
                         
                        }

                    }
                    else
                    {
                        msg = "cant upload empty file";
                        return msg;
                    }

                }
                return msg;
            }
        }
    }

