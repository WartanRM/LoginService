﻿using LoginService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("conName").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO TableName(Name,Email,Password,MobileNumber,Address,City,State,PostalCode,IsActive) VALUES('"+registration.Name+ "','"+registration.Email+"','"+registration.Password+"','"+registration.MobileNumber+"','"+registration.Address+"','"+registration.City+ "','"+registration.State+ "','"+registration.PostalCode+ "','"+registration.IsActive+"'S)", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                return "Data Inserted";
            }
            else
            {
                return "Error";
            }
            return "";
        }
        [HttpPost]
        [Route("login")]
        public string login(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("conName").ToString());

            SqlDataAdapter da =new SqlDataAdapter("SELECT * FROM Registration WHERE Email = '"+registration.Email+"' AND Password= '"+registration.Password+"' AND IsActive = 1 ",con); 
            DataTable dt= new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0) {
                return "Valid User";

            }
            else { return "Invalid User"; }
        }
    }
}
