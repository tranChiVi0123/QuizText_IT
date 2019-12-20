using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using TinHocDaiCuong.DAL;
using System.Text.RegularExpressions;
using System.IO;

namespace TinHocDaiCuong.BLL
{
    #region struct Test
    /// <summary>
    /// int id: mã
    /// String question: câu hỏi
    /// List<String>trueAns: list câu đúng
    /// List<String>wrongAns: list câu sai
    /// </summary>
    struct Test
    {
        public int id;
        public String question;
        public List<String> trueAns;
        public List<String> wrongAns;
    };
    #endregion
    public class DeThi_BLL
    {
        DeThi_DAL dal { get; set; }
        public DeThi_BLL()
        {
            this.dal = new DeThi_DAL();
        }

        public DataTable Get_DeThi_BLL()
        {
            return this.dal.Get_DeThi();
        }

        public void Luu_diem_BLL(String mssv, float diem)
        {
            this.dal.Luu_diem_DAL(mssv,diem);
        }

        public DataTable GetAllDeThi_BLL()
        {
            return this.dal.GetAllDeThi_DAL();
        }
        public int layIDCH(string itemquestion)
        {
            string connStr = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            string query = "SELECT * FROM CauHoi WHERE CauHoi.[Nội dung] = N'"+itemquestion+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connStr);
            adapter.Fill(dt);
            int id = Convert.ToInt32(dt.Rows[1]["Mã câu hỏi"].ToString());
            return id;

        }
        public void addQuestion(string filep)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            QuestionsObject objQ = new QuestionsObject();
            //string filePath = Convert.ToString(Console.ReadLine());
            filep = (@"C:\Users\DELL\Desktop\" + filep).ToString();
            string connStr = @"Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            

            if (objQ.ImportQuestions(filep))
            {
                foreach (Test item in (List<Test>)objQ.Test)
                {
                    string query1 = "INSERT INTO CauHoi([Nội dung]) VALUES(N'" + item.question + "')";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    int idd = layIDCH(item.question);
                    foreach (String item1 in item.trueAns)
                    {
                        string query2 = "INSERT INTO DapAn ([Mã câu hỏi], [Nội dung đáp án]) VALUES(N'"+idd+"', N'"+item1+"')";
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query2, conn))
                        {
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        string query3 = "INSERT INTO DapAnDung ([Mã câu hỏi],[Mã đáp án đúng]) VALUES(N'"+idd+"', N'"+item1+"'); ";
                        using (SqlCommand command = new SqlCommand(query3, conn))
                        {
                            command.ExecuteNonQuery();
                            conn.Close();
                        }

                    }
                    foreach (String item2 in item.wrongAns)
                    {
                        string query4 = "INSERT INTO DapAn ([Mã câu hỏi], [Nội dung đáp án]) VALUES(N'" +idd+ "', N'" +item2+ "')";
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query4, conn))
                        {
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }
            else Console.WriteLine("False");
            Console.ReadLine();

        }
    }
    #region QuestionsObject Class
    public class QuestionsObject
    {
        public int id { get; set; }
        public string quest { get; set; }
        internal List<Test> Test { get => test; set => test = value; }

        public string content;
        private List<Test> test = new List<Test>();

        /// <summary>
        /// readFile
        /// </summary>
        /// <param name="filePath">file address</param>
        /// <returns>boolean</returns>
        private bool ReadFromPlaningText(string filePath)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filePath, true))
                {
                    // Read the stream to a string, and write the string to the console.
                    content = sr.ReadToEnd().Trim();
                    return true;
                }
            }
            catch (Exception)
            {
                throw new System.InvalidOperationException("Không tìm thấy file");
            }
        }

        /// <summary>
        /// Convert Planing text to Questions.Test
        /// </summary>
        /// <returns>boolean</returns>
        private bool ConvertTextToQuestions()
        {
            String[] splitContent = Regex.Split(this.content, @"\d\.\s");

            int i = 0;
            foreach (string item in splitContent)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                Test tempTest = new Test();
                String[] lines = item.Split('\n');
                tempTest.question = lines[0].Trim();
                Regex regexTrueAns = new Regex(@"[-]\. (?<trueAns>((\w+\s)+))");
                Regex regexWrongAns = new Regex(@"[+]\. (?<wrongAns>((\w+\s)+))");
                //or Can use @"[+]\. (?<trueAns>((\w+\s)+))|[-]\. (?<wrongAns>((\w+\s)+))"

                #region Debug firstRegex
                ////Console.WriteLine(splitContent[0]);
                //foreach (string item2 in splitAns)
                //{
                //    Console.WriteLine("Câu"+ i +": "+ "trueAns: " + item2);
                //}
                ////Console.WriteLine("CHUỖI"+i++ + item);
                #endregion

                List<String> trueAnsList = new List<string>();
                List<String> wrongAnsList = new List<string>();
                foreach (Match item2 in regexTrueAns.Matches(item))
                {
                    trueAnsList.Add(item2.Groups["trueAns"].ToString().Trim());
                    //Console.WriteLine("Câu" + i + ": " + "trueAns: " + item2.Groups["trueAns"]);
                }
                foreach (Match item3 in regexWrongAns.Matches(item))
                {
                    wrongAnsList.Add(item3.Groups["wrongAns"].ToString().Trim());
                    //Console.WriteLine("Câu" + i + ": " + "wrongAns: " + item3.Groups["wrongAns"]);
                }

                tempTest.id = i;
                tempTest.trueAns = trueAnsList;
                tempTest.wrongAns = wrongAnsList;

                Test.Add(tempTest);

                i++;
            }
            return true;
        }

        /// <summary>
        /// init Questions
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>boolean</returns>
        public bool ImportQuestions(string filePath)
        {
            if (ReadFromPlaningText(filePath))
            {
                ConvertTextToQuestions();
                return true;
            }
            else
            {
                throw new System.InvalidOperationException("Lỗi đọc file");
            }
        }
    }
    #endregion
}
