using Dapper;
using ForDBA.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ForDBA.Data.Context;
using MySql.Data.MySqlClient;

namespace ForDBA.Data.Repository 
{
    class Repository : IRepository
    {


        string connectionString = DbContext.GetConnectionString();

        public Repository()
        {
           
        }

        public List<Address> GetAddresses()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                return db.Query<Address>("SELECT * FROM Address").ToList();
            }
        }

        public List<Abonent> GetAbonents()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                string sql = @"
            SELECT abonent.*, address.*, phoneNumber.*, street.*
            FROM Abonent abonent
            LEFT JOIN Address address ON address.ID = abonent.AddressID
            LEFT JOIN PhoneNumber phoneNumber ON phoneNumber.AbonentID = abonent.ID
            LEFT JOIN Streets street ON street.ID = address.StreetID
            WHERE 1 = 1
        ";

                var result = db.Query<Abonent, Address, IEnumerable<PhoneNumber>, Streets, Abonent>(
                    sql,
                    (abonent, address, phoneNumber, street) =>
                    {
                        // Обработка результатов запроса
                        address.Street = street;
                        abonent.Address = address;
                        abonent.PhoneNumbers = phoneNumber;
                        return abonent;
                    },
                    splitOn: "ID" // Указываем, по какому столбцу производить разделение объектов
                );

                return result.ToList();
            }
        }

 

        public List<PhoneNumber> GetPhoneNumbers()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                return db.Query<PhoneNumber>("SELECT * FROM PhoneNumber").ToList();
            }
        }

        public List<Streets> GetStreets()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                return db.Query<Streets>("SELECT * FROM Streets").ToList();
            }
        }
    }
}
