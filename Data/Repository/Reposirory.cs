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
using ForDBA.ViewModels;

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
            SELECT abonent.*, address.*, street.*
            FROM Abonent abonent
            LEFT JOIN Address address ON address.ID = abonent.AddressID
            LEFT JOIN Streets street ON street.ID = address.StreetID
            WHERE 1 = 1
        ";

                var result = db.Query<Abonent, Address, Streets, Abonent>(
                    sql,
                    (abonent, address, street) =>
                    {
                        // Обработка результатов запроса
                        address.Street = street;
                        abonent.Address = address;
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

        public List<MainDataGrid> GetMainDataGrids()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                string sql = @"
            SELECT grouppedNumbers.*, abonent.*,  address.*,  street.*
            FROM
            (
                SELECT
                max(case when `Type` = 'HomePhoneNumber' then `Number`  end) HomePhoneNumber,
                max(case when `Type` = 'WorkPhoneNumber' then `Number` end) WorkPhoneNumber,
                max(case when `Type` = 'MobilePhoneNumber' then `Number` end) MobilePhoneNumber,
                `AbonentId`
            FROM u2501067_DBTestTwo.PhoneNumber
            GROUP BY AbonentID  
            ) grouppedNumbers 
            LEFT JOIN Abonent abonent ON abonent.Id = grouppedNumbers.AbonentID
            LEFT JOIN Address address ON address.ID = abonent.AddressID
            LEFT JOIN Streets street ON street.ID = address.StreetID    

        ";

                var result = db.Query< MainDataGrid, Abonent, Address, Streets, MainDataGrid > (
                    sql,
                    (grouppedNumbers, abonent, address, street) =>
                    {
                        // Обработка результатов запроса
                        //address.Street = street;
                        //abonent.Address = address;
                        grouppedNumbers.FIO = $"{abonent.Name} {abonent.LastName} {abonent.SurName}";
                        grouppedNumbers.HomeNumber = address.HomeNumber;
                        grouppedNumbers.StreetName = street.StreetName;


                        return grouppedNumbers;
                    },
                    splitOn: "ID" // Указываем, по какому столбцу производить разделение объектов
                );

                return result.ToList();
            }
        }
    }
}
