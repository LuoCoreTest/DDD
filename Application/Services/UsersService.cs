﻿using Application.Interface.IServices;
using Application.Models.ViewModels;
using Application.Models.ViewModels.User;
using Domain.Interface.ICommandEventsHandler;
using Domain.Interface.IRepository;
using Infrastructure.Interface.IFactory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Application.Services
{
    public class UsersService:BaseService<IUsersRepository>, IUsersService
    {
        public UsersService(ISqlSugarFactory factory, IUsersRepository repository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository) : base(factory, repository, bus, eventStoreRepository)
        {
        }

        public async Task<Boolean> UserRegister(UserCreateViewModel vm)
        {
            //这里引入领域设计中的写命令 还没有实现
            //请注意这里如果是平时的写法，必须要引入Student领域模型，会造成污染
            var registerCommand = new Domain.Models.CommandModels.User.CreateCommandModel(Guid.NewGuid(), vm.UserName, vm.Email, vm.Password, vm.Phone, "用户注册");
            return await Bus.SendCommand(registerCommand);
        }

        public async Task<UserViewModel> UserLogin(UserLoginViewModel vm)
        {

            return await Task.Run<UserViewModel>(() =>
            {
                UserViewModel userRes = new UserViewModel();
                try
                {
          

                    var userData = DbRepository.QueryByNamePassword(vm.UserName, vm.Password);
                    if (userData != null)
                    {
                        userRes.UserId = userData.UserId;
                        userRes.UserName = userData.UserName;
                        userRes.Phone = userData.Phone;
                        userRes.Email = userData.Email;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
                return userRes;

            });
        }


        public IList<Domain.Models.HistoryModels.UserHistoryModel> GetAllHistory()
        {
            return Domain.EventSourcedNormalizers.UserHistory.ToJavaScriptStudentHistory(_EVENTSTOREREPOSITORY.QueryByName("User"));
        }




    }
}
