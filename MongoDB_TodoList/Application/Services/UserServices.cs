using Application.ViewObjects;
using Domain.Entities;
using Domain.Repository;
using Infrastructure;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Application.Services {
    public class UserServices(UnityOfWork unityOfWork, IUserRepository userRepository) {

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserInfo>> GetAllUserInfo() {
            var allUser = await userRepository.GetAllAsync();
            return allUser;
        }

        /// <summary>
        /// 分页查询用户数据
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserInfo>> GetUserInfoByPage(UserPageVm vm) {
            //构造查询条件
            var buildFilter = Builders<UserInfo>.Filter;
            var filter = buildFilter.Empty;
            var sort = Builders<UserInfo>.Sort.Ascending(m => m.CreateTime);

            //根据昵称查询
            if (!string.IsNullOrEmpty(vm.NickName)) {
                filter = buildFilter.Eq(u => u.NickName, vm.NickName);
            }
            //根据id查询
            if (!string.IsNullOrEmpty(vm.Id)) {
                filter = buildFilter.Eq(u => u.Id, vm.Id);
            }

            return await userRepository.FindListByPageAsync(
                filter,
                vm.PageIndex,
                vm.PageSize,
                [],
                sort);
        }

        /// <summary>
        /// 根据id查询用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfoById(string id) {
            return await userRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public async Task<UserInfo> AddUserInfo(UserVm vm) {
            var builder = new UserInfo.Builder()
                .SetUserName(vm.UserName).SetPassword(vm.Password).SetNickName(vm.NickName)
                .SetHeadPortrait(vm.HeadPortrait).SetEmail(vm.Email).SetStatus(vm.Status);
            var userInfo = new UserInfo(builder);

            await userRepository.AddAsync(userInfo);
            return await userRepository.GetByIdAsync(userInfo.Id);
        }

        /// <summary>
        /// 通过事务添加用户信息
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public async Task<UserInfo> AddTransactionUserInfo(UserVm vm) {
            using var session = await unityOfWork.InitTransaction();

            var builder = new UserInfo.Builder()
                .SetUserName(vm.UserName).SetPassword(vm.Password).SetNickName(vm.NickName)
                .SetHeadPortrait(vm.HeadPortrait).SetEmail(vm.Email).SetStatus(vm.Status);
            var userInfo = new UserInfo(builder);

            //调用添加数据的事务操作
            await userRepository.AddTransactionsAsync(session, userInfo);
            var queryUserInfo = await userRepository.GetByIdAsync(userInfo.Id);

            //将事务提交
            await unityOfWork.Commit(session);
            queryUserInfo = await userRepository.GetByIdAsync(userInfo.Id);

            return queryUserInfo;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vm"></param>
        /// <returns></returns>
        public async Task<UserInfo> UpdateUser(string id, UserVm vm) {
            //创建修改条件
            var list = new List<FilterDefinition<UserInfo>> {
                Builders<UserInfo>.Filter.Eq("_id", new ObjectId(id))
            };
            var filter = Builders<UserInfo>.Filter.And(list);
            //指定要修改的字段
            var updateDefinition = Builders<UserInfo>.Update
                .Set(u => u.HeadPortrait, vm.HeadPortrait)
                .Set(u => u.NickName, vm.NickName)
                .Set(u => u.Status, vm.Status);

            await userRepository.UpdateAsync(filter, updateDefinition);

            return await userRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id) {
            await userRepository.DeleteAsync(id);
            var userInfo = (UserInfo?) await userRepository.GetByIdAsync(id);
            return userInfo == null;
        }
    }
}
