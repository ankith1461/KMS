using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ionic.Zip;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using DataAccessLayer;


namespace BusinessLayer
{
    public class Bal_Bulk : System.Web.UI.Page
    {
       // public int[] arr_status;
        public DataTable UploadArticle(String path,out int [] arr_status)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subdir = null;
            string RootDir = null;
            try
            {
                Directory.CreateDirectory(Server.MapPath("~/ExtractFiles"));
                using (ZipFile zip = ZipFile.Read(path))// name of existing file system
                {
                    zip.ExtractAll(Server.MapPath("~/ExtractFiles"), ExtractExistingFileAction.OverwriteSilently);
                }
                DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/ExtractFiles"));//get directory info
                subdir = d.GetDirectories();
                FileInfo[] ExcelFiles = subdir[0].GetFiles("*.xls*");//search for excel files
                if (ExcelFiles.Length > 1)
                    throw new Exception("More than one excel file Found");
                else if (ExcelFiles.Length == 0)
                    throw new Exception("No excel file found");
                else
                {
                    files = subdir[0].GetFiles(); // work according to excel file type                
                    RootDir = Server.MapPath("~/ExtractFiles/" + subdir[0].Name + "/");
                    String fileLocation = RootDir + ExcelFiles[0].Name;
                    DataTable dt = ReadExcel(fileLocation, RootDir, out arr_status);// read excel file                

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                foreach (var f in files)// deleting files
                {
                    f.Delete();
                }
                foreach (var f in subdir)// deleting directories
                {
                    f.Delete();
                }
            }
        }
        private DataTable ReadExcel(String fileLocation, String RootDir,out int [] arr_status)
        {

            String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            try
            {
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                con.Open();
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                dAdapter.SelectCommand = cmd;
                DataTable dtExcelRecords = new DataTable();
                dAdapter.Fill(dtExcelRecords);
                ParseExcelInformation(dtExcelRecords, RootDir, out arr_status);
                return dtExcelRecords;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        private void ParseExcelInformation(DataTable excelData, String RootDir,out int [] arr_status)
        {
            try
            {
                arr_status = new int[excelData.Rows.Count];
                Array.Clear(arr_status, 0, arr_status.Length);
                if (excelData.Columns.Count != 12)
                    throw new Exception("Excel Sheet is not in proper format ");
                else
                {

                    for (int i = 0; i < excelData.Rows.Count; i++)
                    {
                       
                        bool hasAllField = true;
                        for (int j = 2; j < 8; j++)//first 6 column
                        {
                            if (excelData.Rows[i][j].ToString() == "")
                            {
                                hasAllField = false;
                                break;
                            }
                        }
                        if (excelData.Rows[i][0].ToString() == "")
                            hasAllField = false;
                        if (hasAllField)
                        {
                            SqlParameter[] objDataParams = new SqlParameter[11];// 11 is fixed
                            objDataParams[0] = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 50);
                            if(excelData.Rows[i][0].ToString().Length<=500)
                                objDataParams[0].Value = excelData.Rows[i][0].ToString();
                            {
                            objDataParams[1] = new SqlParameter("@ArtType", System.Data.SqlDbType.NVarChar, 25);
                            objDataParams[1].Value = excelData.Rows[i][1].ToString();

                            objDataParams[2] = new SqlParameter("@AppName", System.Data.SqlDbType.NVarChar, 65);
                            objDataParams[2].Value = excelData.Rows[i][2].ToString();

                            objDataParams[3] = new SqlParameter("@Collection", System.Data.SqlDbType.NVarChar, 25);
                            objDataParams[3].Value = excelData.Rows[i][3].ToString();

                            objDataParams[4] = new SqlParameter("@Priority", System.Data.SqlDbType.NVarChar, 20);
                            objDataParams[4].Value = excelData.Rows[i][4].ToString();

                            objDataParams[5] = new SqlParameter("@ProbStmt", System.Data.SqlDbType.NVarChar, 500);
                            objDataParams[5].Value = excelData.Rows[i][5].ToString();

                            objDataParams[6] = new SqlParameter("@Details", System.Data.SqlDbType.NVarChar, 1037741823);
                            if (excelData.Rows[i][6].ToString().Length <= 3000)
                            
                            {
                            objDataParams[6].Value = excelData.Rows[i][6].ToString();


                            objDataParams[7] = new SqlParameter("@AddInformation", System.Data.SqlDbType.NVarChar, 100);
                            objDataParams[7].Value = excelData.Rows[i][7].ToString();

                            objDataParams[8] = new SqlParameter("@CreatedBy", System.Data.SqlDbType.Decimal, 10);
                            objDataParams[8].Value = Session["CognizantId"];//initially fixed

                            objDataParams[9] = new SqlParameter("@ArtId", System.Data.SqlDbType.NVarChar, 10);
                            objDataParams[9].Direction = ParameterDirection.Output;

                            objDataParams[10] = new SqlParameter("@colid", System.Data.SqlDbType.NVarChar, 16);
                            objDataParams[10].Direction = ParameterDirection.Output;


                            Dal_Bulk ob = new Dal_Bulk();
                            String artid, collid;
                           ob.InsertArtInformation(objDataParams, out artid, out collid);

                            ////////////////////////////////////////////////////////////////////////////////////////////////////
                            String tag = excelData.Rows[i][8].ToString();
                            String[] tags = tag.Split(';', ',');// comma or semiclone separated

                            foreach (string s in tags)
                            {
                                SqlParameter[] tagParams = new SqlParameter[4];// 9 is fixed
                                tagParams[0] = new SqlParameter("@colid", System.Data.SqlDbType.NVarChar, 50);
                                tagParams[0].Value = collid;

                                tagParams[1] = new SqlParameter("@articleid", System.Data.SqlDbType.NVarChar, 25);
                                tagParams[1].Value = artid;

                                tagParams[2] = new SqlParameter("@tag", System.Data.SqlDbType.NVarChar, 100);
                                tagParams[2].Value = s;

                                tagParams[3] = new SqlParameter("@createdBy", System.Data.SqlDbType.Decimal);
                                tagParams[3].Value = Convert.ToDecimal(Session["CognizantId"]);//initially fixed
                                Dal_Bulk ob1 = new Dal_Bulk();

                                ob1.InsertTagData(tagParams);
                            }
                            ///////////////////////////////////////////////////////////////////////////////
                            for (int j = 9; j < excelData.Columns.Count; j++)
                            {
                                arr_status[i] = 1;
                                if (excelData.Rows[i][j].ToString() != "")
                                {
                                    String fileExtension = Path.GetExtension(excelData.Rows[i][j].ToString());
                                    String fileName = excelData.Rows[i][j].ToString();
                                    String[] matchExtension = { ".jpg", ".doc", ".docx", ".xls", ".ppt", ".pptx", ".pdf", ".bmp", ".txt", ".zip",".rar" };
                                    if (File.Exists(RootDir + fileName))// +fileExtension
                                    {
                                        if (matchExtension.Contains(fileExtension))
                                        {

                                            SqlParameter[] objData = new SqlParameter[4];// 3 is fixed
                                            objData[0] = new SqlParameter("@SuppDocName", System.Data.SqlDbType.NVarChar, 25);
                                            objData[0].Value = excelData.Rows[i][j].ToString();

                                            objData[1] = new SqlParameter("@SuppDocType", System.Data.SqlDbType.NVarChar, 20);
                                            objData[1].Value = Path.GetExtension(excelData.Rows[i][j].ToString());

                                            objData[2] = new SqlParameter("@SuppDocData", System.Data.SqlDbType.Image);
                                            objData[2].Value = BinaryData(RootDir, excelData.Rows[i][j].ToString());

                                            objData[3] = new SqlParameter("@ArtId", System.Data.SqlDbType.NVarChar);
                                            objData[3].Value = artid;// comming from first data

                                            Dal_Bulk ob2 = new Dal_Bulk();
                                             ob2.InsertSuppDoc(objData);
                                            arr_status[i] = 1;
                                        }
                                        else arr_status[i] = 0;
                                    }
                                    else arr_status[i] = 0;
                                }
                                else arr_status[i] = 1;
                            }
                        }//end of if          
                    }}}//end of for
                }
                
            }// end of try
            //------------------------------------------------------------------------
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Byte[] BinaryData(String RootDir, String fileName)//change extension String ext
        {
            Byte[] bytes = File.ReadAllBytes(RootDir + fileName); //br.ReadBytes((Int32)fs.Length);  //counting the file length into bytes
            return bytes;
        }
    }
}