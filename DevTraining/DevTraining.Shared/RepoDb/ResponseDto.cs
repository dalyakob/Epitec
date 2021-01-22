using DevTraining.Core.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevTraining.Shared
{
    public class ResponseDto : BaseRepository<Contact, SqlConnection>, IResponseDto
    {

        public ResponseDto(string connectionString): base (connectionString)
        {        }

        public  Contact GetById(Guid id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var contact = connection.Query<Contact>(e => e.Id == id).FirstOrDefault();

                return contact;
            }
        }
    }
}
