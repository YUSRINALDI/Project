using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelloiteTRLib.Repository;
using vm = DelloiteTRLib.Model;
using dc = DelloiteTRLib.DataContext;
using System.Security.Cryptography;

namespace DelloiteTRLib.Services
{
    public class UserServices
    {
        private UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public List<vm.User> GetUsers()
        {

            List<vm.User> vmUsers = new List<vm.User>();
            IEnumerable<dc.User> users = null;
            try
            {
                users = _userRepository.FindAll();
                if (users != null)
                {

                    foreach (dc.User user in users)
                    {
                        vm.User vmUser = new vm.User();
                        vmUser.username = user.username;
                        vmUser.password = user.password;
                        vmUser.suspended = user.suspended;
                        vmUser.deleted = user.deleted;
                        vmUser.roleid = user.roleid;
                        vmUser.fullname = user.fullname;
                        vmUser.email = user.email;
                        vmUser.created = user.created;
                        vmUser.updated = user.updated;
                        vmUser.token = user.token;
                        vmUser.tokendate = user.tokendate;

                        vmUsers.Add(vmUser);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmUsers;
        }


        public vm.User GetUser(string username)
        {
            vm.User vmUser = null;
            dc.User user = null;

            try
            {
                user = _userRepository.FindByUsername(username);
                if (user != null)
                {
                    vmUser = new vm.User();
                    vmUser.username = user.username;
                    vmUser.password = user.password;
                    vmUser.suspended = user.suspended;
                    vmUser.deleted = user.deleted;
                    vmUser.roleid = user.roleid;
                    vmUser.fullname = user.fullname;
                    vmUser.email = user.email;
                    vmUser.created = user.created;
                    vmUser.updated = user.updated;
                    vmUser.token = user.token;
                    vmUser.tokendate = user.tokendate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmUser;
        }

        public vm.User Login(string username, string password)
        {
            vm.User vmUser = null;
            dc.User user = null;

            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    password = Hash.GetMd5Hash(md5Hash, password);
                }

                user = _userRepository.Login(username, password);
                if (user != null)
                {
                    vmUser = new vm.User();
                    vmUser.username = user.username;
                    vmUser.password = user.password;
                    vmUser.suspended = user.suspended;
                    vmUser.deleted = user.deleted;
                    vmUser.roleid = user.roleid;
                    vmUser.fullname = user.fullname;
                    vmUser.email = user.email;
                    vmUser.created = user.created;
                    vmUser.updated = user.updated;
                    vmUser.token = user.token;
                    vmUser.tokendate = user.tokendate;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmUser;
        }

        public bool Create(string username, string password, short suspended, short deleted
            , short roleid, string fullname, string email, string created, string updated
            , string token, string tokendate)
        {
            bool boolInsert = false;
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    password = Hash.GetMd5Hash(md5Hash, password);
                }

                boolInsert = _userRepository.Insert(username, password, suspended, deleted
            , roleid, fullname, email, created, updated
            , token, tokendate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolInsert;
        }

        public bool ChangePassword(string username, string password, string updated)
        {
            bool boolUpdate = false;
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    password = Hash.GetMd5Hash(md5Hash, password);
                }
                boolUpdate = _userRepository.ChangePassword(username, password, updated);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolUpdate;
        }

        public bool Update(string username, short roleid, string fullname, string email, short suspended, string updated)
        {
            bool boolUpdate = false;
            try
            {
                boolUpdate = _userRepository.Update(username, roleid, fullname, email, suspended, updated);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolUpdate;
        }

        public bool Delete(string username)
        {
            bool boolDelete = false;
            try
            {
                boolDelete = _userRepository.Delete(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolDelete;
        }

        public bool ForceDelete(string username)
        {
            bool boolDelete = false;
            try
            {
                boolDelete = _userRepository.ForceDelete(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolDelete;
        }

        public bool Suspend(string username)
        {
            bool boolDelete = false;
            try
            {
                boolDelete = _userRepository.Suspend(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return boolDelete;
        }

        public void Dispose()
        {
            if (_userRepository != null)
            {
                _userRepository.Dispose();
                _userRepository = null;
            }
        }

    }
}

