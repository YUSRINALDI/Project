using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Database;
using System.Data.SqlClient;
using dc = DelloiteTRLib.DataContext;

namespace DelloiteTRLib.Repository
{
    public class UserRepository
    {
        private SqlServerDatabase _database;
        private dc.DelloiteDataContext _dataContext;

        public UserRepository()
        {
        }

        public void SetDatabase(SqlServerDatabase database)
        {
            _database = database;
        }

        public void SetDataContext(dc.DelloiteDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<dc.User> FindAll()
        {
            IEnumerable<dc.User> users = new List<dc.User>();
            try
            {
                users = _dataContext.Users.ToList<dc.User>();
                users = from user in _dataContext.Users select user;
                users = users.Where(x => x.deleted == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }



        public dc.User FindByUsername(string username)
        {
            dc.User user = null;           
           
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                Where(p => p.deleted == 0).
                                SingleOrDefault<dc.User>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public dc.User FindByFullname(string fullname)
        {
            dc.User user = null;

            try
            {
                user = _dataContext.Users.
                                Where(p => p.fullname.ToLower().Contains(fullname.ToLower())).
                                Where(p => p.suspended == 0).
                                Where(p => p.deleted == 0).
                                SingleOrDefault<dc.User>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public dc.User Login(string username, string password)
        {
            dc.User user = null;

            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                Where(p => p.password == password).
                                Where(p => p.suspended == 0).
                                Where(p => p.deleted == 0).
                                SingleOrDefault<dc.User>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public bool Insert(string username, string password, short suspended, short deleted
            , short roleid, string fullname, string email, string created, string updated
            , string token, string tokendate)
        {
            dc.User user = null;
            try
            {
                user = new dc.User();
                user.username = username;
                user.password = password;
                user.suspended = suspended;
                user.deleted = deleted;
                user.roleid = roleid;
                user.fullname = fullname;
                user.email = email;
                user.created = created;
                user.updated = updated;
                user.token = token;
                user.tokendate = tokendate;


                _dataContext.Users.InsertOnSubmit(user);
                _dataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool ChangePassword(string username, string password, string updated)
        {
            dc.User user = null;
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                SingleOrDefault<dc.User>();
                if (user != null)
                {
                    user.password = password;
                    user.updated = updated;

                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }

        public bool Update(string username, short roleid, string fullname,string email,short suspended, string updated)       
        {
            dc.User user = null;
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                SingleOrDefault<dc.User>();
                if (user != null)
                {
                    user.roleid = roleid;
                    user.fullname = fullname;
                    user.email = email;
                    user.suspended = suspended;
                    user.updated = updated;

                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
            
        }
        
        public bool ForceDelete(string username)
        {
            dc.User user = null;
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                SingleOrDefault<dc.User>();
                if (user != null)
                {
                    _dataContext.Users.DeleteOnSubmit(user);
                    _dataContext.SubmitChanges();
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }        

            return true;
        }

        public bool Delete(string username)
        {
            dc.User user = null;
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                SingleOrDefault<dc.User>();
                if (user != null)
                {
                    user.deleted = 1;

                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }

        public bool Suspend(string username)
        {
            dc.User user = null;
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                SingleOrDefault<dc.User>();
                if (user != null)
                {
                    user.suspended = 1;

                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }

        public bool InsertToken(string username, string token, string tokendate)
        {
            dc.User user = null;
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                SingleOrDefault<dc.User>();
                if (user != null)
                {
                    user.token = token;
                    user.tokendate = tokendate;

                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }

        public bool DeleteToken(string username)
        {
            dc.User user = null;
            try
            {
                user = _dataContext.Users.
                                Where(p => p.username == username).
                                SingleOrDefault<dc.User>();
                if (user != null)
                {
                    user.token = "";
                    user.tokendate = "";

                    _dataContext.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }
        

        public void Dispose()
        {
            if (_database != null)
            {
                _database.Dispose();
                _database = null;
            }

            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
        }
    }
}
