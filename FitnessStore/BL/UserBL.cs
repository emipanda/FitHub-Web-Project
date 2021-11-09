using FitnessStore.Data;
using FitnessStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessStore.BL
{
    public class UserBL
    {

        private readonly FitnessStoreContext db;

        public UserBL(FitnessStoreContext db) => this.db = db;


        public ValueTask<User> GetUser(int id)
        {
            return this.db.User.FindAsync(id);
        }

        public List<User> GetUsers()
        {
            return this.db.User.ToList();
        }

        public Task<int> Create(User user)
        {
            this.db.User.Add(user);
            return this.db.SaveChangesAsync();
        }

        public Task<int> Edit(User user)
        {
            this.db.User.Update(user);
            return this.db.SaveChangesAsync();
        }

        public async Task<User> Delete(int id)
        {
            User user = await this.GetUser(id);

            this.db.User.Remove(user);

            await this.db.SaveChangesAsync();

            return user;
        }

    }
}
