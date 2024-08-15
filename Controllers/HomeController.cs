using ApiGeneration.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
namespace ApiGeneration.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        [Route("/LoginDetailsUser")]
        public JsonResult UserLoginDetailsA([FromBody] UserDetailsLogin e)
        {
            UserDetails em = null;

            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "select * from UserDetails";
            SqlCommand cmd = new SqlCommand("UserLoginDetails", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", e.email);
            cmd.Parameters.AddWithValue("@password", e.password);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                em = new UserDetails
                {
                    statusCode = 200,
                    email = (string)read["email"],
                    fName = (string)read["fName"],
                    lName = (string)read["lName"],
                    pImage = (string)read["pImage"],
                    userId = (int)read["userId"],
                    vehicleNo = (string)read["vehicleNo"],
                    area = (string)read["area"],
                    city = (string)read["city"],
                    pincode = (int)read["pincode"],
                    phone = (string)read["mobileNo"],
                    vehicleName = (string)read["vehicleName"],
                };
            }
            conn.Close();
            if (em == null)
            {
                return Json(new
                {
                    statusCode = 400,
                    success = false
                });
            }

            return Json(em);

        }

        [HttpGet]
        [Route("/GetTheUserList")]
        public JsonResult GetAllUsers()
        {
            List<UserDetails> l = new List<UserDetails>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "select * from Addresses";
            SqlCommand cmd = new SqlCommand("getUser", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                l.Add(new UserDetails
                {
                    statusCode = 200,
                    email = (string)read["email"],
                    fName = (string)read["fName"],
                    lName = (string)read["lName"],
                    pImage = (string)read["pImage"],
                    userId = (int)read["userId"],
                    vehicleNo = (string)read["vehicleNo"],
                    area = (string)read["area"],
                    city = (string)read["city"],
                    pincode = (int)read["pincode"],
                    phone = (string)read["mobileNo"],
                    vehicleName = (string)read["vehicleName"],
                });
            }
            conn.Close();
            return Json(l);

        }
        [HttpGet]
        [Route("/GetUserById")]
        public JsonResult getUserById(int userId)
        {
            UserDetailsWithId em = null;
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "SELECT * from UserDetails where userId = "+ userId;
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                em=new UserDetailsWithId
                {
                    statusCode =200,
                    userId = (int)read["userId"],
                    email = (string)read["email"],
                    fName = (string)read["fName"],
                    lName = (string)read["lName"],
                    pImage = (string)read["pImage"],
                    vehicleNo = (string)read["vehicleNo"],
                    area = (string)read["area"],
                    city = (string)read["city"],
                    pincode = (int)read["pincode"],
                    phone = (string)read["mobileNo"],
                    vehicleName = (string)read["vehicleName"],
                };
            }
            conn.Close();
            return Json(em);
        }


        [HttpGet]
        [Route("/GetServiceWithUser")]
        public JsonResult GetServiceList(int userId)
        {
            List<ServiceTimings> sL = new List<ServiceTimings>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from ServiceList where userId = "+userId;
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                sL.Add ( new ServiceTimings
                {
                    statusCode = 200,
                    serviceId = (int)read["serviceId"],
                    userId = (int)read["userId"],
                    Timings = (DateTime)read["Timings"],
                    DateAndTime = (string)read["DateAndTime"]

                });
            }
            conn.Close();
            return Json(sL);
        }


        [HttpPost]
        [Route("/AddServiceTimings")]
        public JsonResult AddServiceTimings([FromBody] AddServiceTime e)
        {
            //List<ServiceTimings> aS= new List<ServiceTimings>();

            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "insert into ServiceList values("+e.userId+","+e.Timings+")";
            SqlCommand cmd = new SqlCommand("AddServiceTimings", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@serviceId", e.serviceId);
            cmd.Parameters.AddWithValue("userId", e.userId);
            cmd.Parameters.AddWithValue("Timings", e.Timings);
            cmd.Parameters.AddWithValue("DateAndTime",e.DateAndTime);
           // SqlDataReader read = cmd.ExecuteReader();
            string em=cmd.ExecuteScalar().ToString();
          //string em = ""
            conn.Close();
            if (em != "successfully added")
            {
                return Json(new
                {
                    statusCode = 400,
                    success = false
                });
            }

            return Json(new
            {
                statusCode = 200,
                status = em.ToString(),
            });

        }

        [HttpGet]
        [Route("/GetAllServiceWithUser")]
        public JsonResult GetAllServiceList()
        {
            List<ServiceTimings> sL = new List<ServiceTimings>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from ServiceList Order by Timings Desc";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                sL.Add(new ServiceTimings
                {
                    statusCode = 200,
                    serviceId = (int)read["serviceId"],
                    userId = (int)read["userId"],
                    Timings = (DateTime)read["Timings"],
                    DateAndTime = (string)read["DateAndTime"]

                });
            }
            conn.Close();
            return Json(sL);
        }



        [HttpPost]
        [Route("/AddUsersDetails")]
        public JsonResult AddUsersDetails([FromBody] AddUserDetails e)
        {
           // List<ServiceTimings> aS = new List<ServiceTimings>();

            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "insert into UserDetails values("+e.fName+","+e.lName+","+e.email+","+e.pImage+ ","+e.vehicleNo+","+e.area+","+e.city+","+e.pincode+ ","+e.vehicleName+")";
            SqlCommand cmd = new SqlCommand("AddUserDetails", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@serviceId", e.serviceId);
            cmd.Parameters.AddWithValue("fName", e.fName);
            cmd.Parameters.AddWithValue("lName", e.lName);
            cmd.Parameters.AddWithValue("email", e.email);
            cmd.Parameters.AddWithValue("password", e.password);
            cmd.Parameters.AddWithValue("pImage", e.pImage);
            cmd.Parameters.AddWithValue("vehicleNo", e.vehicleNo);
            cmd.Parameters.AddWithValue("area", e.area);
            cmd.Parameters.AddWithValue("city", e.city);
            cmd.Parameters.AddWithValue("pincode", e.pincode);
            cmd.Parameters.AddWithValue("mobileNo", e.phone);
            cmd.Parameters.AddWithValue("vehicleName", e.vehicleName);
            // SqlDataReader read = cmd.ExecuteReader();
            string em = cmd.ExecuteScalar().ToString();
            //string em = ""
            conn.Close();
            if (em != "Added Successfully")
            {
                return Json(new
                {
                    statusCode = 400,
                    success = false
                });
            }

            return Json(new
            {
                statusCode = 200,
                status = em.ToString(),
            });

        }

        [HttpGet]
        [Route("/GetServiceWithIds")]
        public JsonResult GetServiceListWithIds(int userId,int serviceId)
        {
            ServiceTimings sL = null;
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from ServiceList where userId= "+userId+" and serviceId= "+serviceId;
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                sL=new ServiceTimings
                {
                    statusCode = 200,
                    serviceId = (int)read["serviceId"],
                    userId = (int)read["userId"],
                    Timings = (DateTime)read["Timings"],
                    DateAndTime = (string)read["DateAndTime"]

                };
            }
            conn.Close();
            return Json(sL);
        }

        [HttpPost]
        [Route("/AddConfirmation")]
        public JsonResult AddConfirmation([FromBody] Confirmations e)
        {
            // List<ServiceTimings> aS = new List<ServiceTimings>();

            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "insert into UserDetails values("+e.fName+","+e.lName+","+e.email+","+e.pImage+ ","+e.vehicleNo+","+e.area+","+e.city+","+e.pincode+ ","+e.vehicleName+")";
            SqlCommand cmd = new SqlCommand("AddConfirmation", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@serviceId", e.serviceId);
            cmd.Parameters.AddWithValue("userId", e.userId);
            cmd.Parameters.AddWithValue("serviceId", e.serviceId);
            cmd.Parameters.AddWithValue("statusU", e.status);
            cmd.Parameters.AddWithValue("messageU", e.message);
            // SqlDataReader read = cmd.ExecuteReader();
            string em = cmd.ExecuteScalar().ToString();
            //string em = ""
            conn.Close();
            if (em != "success")
            {
                return Json(new
                {
                    statusCode = 400,
                    success = false
                });
            }

            return Json(new
            {
                statusCode = 200,
                status = em.ToString(),
            });

        }


        [HttpGet]
        [Route("/GetConfirmUserId")]
        public JsonResult GetConfirmationWithUsers(int userId)
        {
            List<ConfirmationsListUser> sL =new List<ConfirmationsListUser>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from Schedule where userId="+ userId;
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                sL.Add(new ConfirmationsListUser
                {
                    statusCode = 200,
                    scheduleId = (int)read["scheduleId"],
                    userId = (int)read["userId"],
                    serviceId = (int)read["serviceId"],
                    status = (string)read["statusU"],
                    message = (string)read["messageU"]

                });
            }
            conn.Close();
            return Json(sL);
        }

        [HttpGet]
        [Route("/GetSearchedUsers")]
        public JsonResult GetSearchedUsers(string firstName)
        {
            List<UserDetails> l = new List<UserDetails>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "SELECT userId,email,fName,lName,pImage,vehicleNo,area,city,pincode,mobileNo,vehicleName FROM UserDetails where fName="+firstName;
            SqlCommand cmd = new SqlCommand("SearchedUser", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                l.Add(new UserDetails
                {
                    statusCode = 200,
                    email = (string)read["email"],
                    fName = (string)read["fName"],
                    lName = (string)read["lName"],
                    pImage = (string)read["pImage"],
                    userId = (int)read["userId"],
                    vehicleNo = (string)read["vehicleNo"],
                    area = (string)read["area"],
                    city = (string)read["city"],
                    pincode = (int)read["pincode"],
                    phone = (string)read["mobileNo"],
                    vehicleName = (string)read["vehicleName"],
                });
            }
            conn.Close();
            return Json(l);
        }

        [HttpPost]
        [Route("/Image")]
        public JsonResult ImageUpload([FromBody] Image e)
        {
            //Image em = null;

            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=ImagePath; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            //string q = "select * from UserDetails";
            SqlCommand cmd = new SqlCommand("upImage", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("imageName", e.Img);
           // SqlDataReader read = cmd.ExecuteReader();
           string em=cmd.ExecuteScalar().ToString();
            conn.Close();
            if (em!="Success")
            {
               return Json(new
               {
                   statusCode=400,
                   success=false
               });
            }
            
            else
            {
                return Json(new
                {
                    statusCode = 200,
                    success = em
                });
            }
        }

        [HttpGet]
        [Route("/GetProducts")]
        public JsonResult GetProduct()
        {
            List<Products> l = new List<Products>();
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from Products";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                l.Add(new Products
                {
                    statusCode = 200,
                    productId = (int)read["productId"],
                    productName = (string)read["productName"],
                    productPrice = (int)read["productPrice"],
                    productDescription = (string)read["productDesc"],
                    productImage = (string)read["productImage"],
                    productRating = (int)read["rating"],
                });
            }
            conn.Close();
            return Json(l);

        }
        [HttpGet]
        [Route("/GetProductsWithId")]
        public JsonResult GetProductWithId(int productId)
        {
            Products products= null;
            string conString = "Data Source=BalaSivanantham\\SQLEXPRESS; Initial Catalog=bikeProject; Integrated Security=True; Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string q = "select * from Products where productId ="+productId;
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                products = new Products
                {
                    statusCode = 200,
                    productId = (int)read["productId"],
                    productName = (string)read["productName"],
                    productPrice = (int)read["productPrice"],
                    productDescription = (string)read["productDesc"],
                    productImage = (string)read["productImage"],
                    productRating = (int)read["rating"],
                };
            }
            conn.Close();
            return Json(products);

        }
    }
}
