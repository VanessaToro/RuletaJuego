using RouletteGame_WebApi.Business.Interfaces;
using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly RouletteGameContext _context;
        MessageError messageError = new();

        public UserBusiness(RouletteGameContext context)
        {
            _context = context;
        }
        public RequestResponse CreateUser(User user)
        {
            try
            {
                RequestResponse response = new RequestResponse();
                User userModel = new User
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    DocumentIdentification = user.DocumentIdentification,
                    Password = EncryptPasswordUser(user.Password),
                    Credit = user.Credit,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                _context.User.Add(userModel);
                _context.SaveChanges();
                response.SuccessFul = true;

                return response;
            }
            catch (Exception ex)
            {
                return messageError.MapResponseError(ex.Message);
            }
        }

        public string DecryptPasswordUser(string encriptPassword)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] result = Convert.FromBase64String(encriptPassword);
                return UTF8Encoding.UTF8.GetString(result);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public string EncryptPasswordUser(string password)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                byte[] result = md5.Hash;
                return Convert.ToBase64String(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
