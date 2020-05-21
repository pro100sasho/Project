using Data;
using Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class UserServices
    {
        public readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            this._context = context;
        }

        public void Create(User user)
        {            
            _context.Add(user);
            _context.SaveChanges();                
            
        }
        public List<User> GetAll()
        {
            return new List<User>(_context.Users);       
        }

        public User GetById(int id)
        {           
            User user = _context.Users.FirstOrDefault(m => m.Id == id);
            
            return user;
        }

        
    }

}
