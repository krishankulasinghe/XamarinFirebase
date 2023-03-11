using Firebase.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinFirebaseApp
{
    public class ConfigFirebase
    {
        public static string FirebaseClient = "https://xamarinfirebase-e9288-default-rtdb.firebaseio.com/";
    }
    public class StudentRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient(ConfigFirebase.FirebaseClient);
        public async Task<bool> Save(StudentModel student)
        {
            try
            {
                var data = await firebaseClient.Child("StudentModel").PostAsync(JsonConvert.SerializeObject(student));
                if (!string.IsNullOrEmpty(data.Key))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<StudentModel>> GetAll()
        {
            try
            {
                return (await firebaseClient.Child(nameof(StudentModel)).OnceAsync<StudentModel>()).Select(item => new StudentModel
                {
                    Email = item.Object.Email,
                    Id = item.Key,
                    Name = item.Object.Name,
                    Image = item.Object.Image,
                }).ToList();
            }
            catch (Exception e)
            {


            }

            return new List<StudentModel>();
        }
    }
}
