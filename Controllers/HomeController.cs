using ApiGeneration.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace ApiGeneration.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("/")]
        public JsonResult Index()
        {
            return Json(new {fact="This is Fact",length=56});
        }

        [HttpGet]
        [Route("/list")]
        public JsonResult Value() 
        {
            List<ModelClass> l = new List<ModelClass>();
            List<ModelClass> l2 = new List<ModelClass>();

            l.Add(new ModelClass { IdNation = "5tyuio", Nation = "USA", IdYear = 2022, Year = "2345", Population = 345678, SlugNation = "sdfghj" });
            l.Add(new ModelClass { IdNation = "5tyuio", Nation = "USA", IdYear = 2022, Year = "2345", Population = 345678, SlugNation = "sdfghj" });
            l.Add(new ModelClass { IdNation = "5tyuio", Nation = "USA", IdYear = 2022, Year = "2345", Population = 345678, SlugNation = "sdfghj" });
            l.Add(new ModelClass { IdNation = "5tyuio", Nation = "USA", IdYear = 2022, Year = "2345", Population = 345678, SlugNation = "sdfghj" });
            l2.Add(new ModelClass { IdNation = "5tyuio", Nation = "USA", IdYear = 2022, Year = "2345", Population = 345678, SlugNation = "sdfghj" });
            l2.Add(new ModelClass { IdNation = "5tyuio", Nation = "USA", IdYear = 2022, Year = "2345", Population = 345678, SlugNation = "sdfghj" });
            l2.Add(new ModelClass { IdNation = "5tyuio", Nation = "USA", IdYear = 2022, Year = "2345", Population = 345678, SlugNation = "sdfghj" });

            return Json(new { x =  l , g =l2 });
        }

        [HttpGet]
        [Route("/Ob")]
        public JsonResult Obj() 
        {
            return Json(new {
                time=new { updated="rtyuiol",updatedIso="dtyuio",updateduk="fghjk"},
                disclaimer="sdfghjkdvbnm",
                chartName="dfgtyhujikkjhgfc",
                bpi=new{
                usd = new { code="usd",symbol="4567hj",rate="345678",description="United Doller",rate_float=56789},
                gbp = new { code = "usd", symbol = "4567hj", rate = "345678", description = "United Doller", rate_float = 56789 },
                eur=new { code = "usd", symbol = "4567hj", rate = "345678", description = "United Doller", rate_float = 56789 }
            } });
        }

        [HttpGet]
        [Route("/Sample")]
        public JsonResult Sample()
        {
            return Json(new {count=12,name="dfg",gender="male",probability=345.2 });
        }

        [HttpGet]
        [Route("/DbData1")]
        public JsonResult DbData()
        {
            List<Addresses> l = new List<Addresses>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=RunGroups; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from Addresses";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                l.Add(new Addresses
                {
                    Id = (int)read["Id"],
                    Street = (string)read["Street"],
                    State = (string)read["State"],
                    City = (string)read["City"],
                });
            }
            conn.Close();
            return Json(l);

        }

        [HttpGet]
        [Route("/Id")]
        public JsonResult getDataById(int Id)
        {
            List<Addresses> l = new List<Addresses>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=RunGroups; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from Addresses where Id ="+Id;
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                l.Add(new Addresses
                {
                    Id = (int)read["Id"],
                    Street = (string)read["Street"],
                    State = (string)read["State"],
                    City = (string)read["City"],
                });
            }
            conn.Close();
            return Json(l);
        }
        [HttpGet]
        [Route("/SpGet")]
        public JsonResult getAllsp()
        {
            List<employee> l = new List<employee>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=office; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "select * from Addresses";
            SqlCommand cmd = new SqlCommand("getsp", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                l.Add(new employee
                {
                    eid = (int)read["eid"],
                    place = (string)read["place"],
                    role = (string)read["role"],
                    salery = (int)read["salery"],
                });
            }
            conn.Close();
            return Json(l);

        }
        [HttpPost]
        [Route("/SpInsert")]
        public JsonResult insertsp([FromBody] employee e)
        {
            //List<employee> l = new List<employee>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=office; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "select * from Addresses";
            SqlCommand cmd = new SqlCommand("insertsp", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("eid",e.eid);
            cmd.Parameters.AddWithValue("place",e.place);
            cmd.Parameters.AddWithValue("role",e.role);
            cmd.Parameters.AddWithValue("salery",e.salery);
            string r=cmd.ExecuteScalar().ToString();
            conn.Close();
            if (r == "success")
            {
                return Json(new {success=true});
            }
            else
            {
                return Json(new {success=false});
            }

        }
    }
}
