using AgendaWeb.Infra.Data.Entities;
using AgendaWeb.Infra.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWeb.Infra.Data.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly string _connectionstring;

        public EventoRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void Create(Evento obj)
        {
            var query = @"
                   INSERT INTO EVENTO(ID,NOME,DATA,HORA,DESCRICAO, PRIORIDADE,DATAINCLUSAO,DATAALTERACAO, IDUSUARIO)
                   VALUES(@ID,@NOME,@DATA,@HORA,@DESCRICAO, @PRIORIDADE,@DATAINCLUSAO,@DATAALTERACAO, @IDUSUARIO) ";
            //conectando no banco de dados
            using (var connection = new SqlConnection(_connectionstring))
            {
                //executando a gravação do evento na base de dados
                connection.Execute(query, obj);
            }

        }

        public void Update(Evento obj)
        {
            var query = @"
                UPDATE EVENTO 
                SET 
                    NOME = @Nome,
                    DATA = @Data,
                    HORA = @Hora,
                    DESCRICAO = @Descricao,
                    PRIORIDADE = @Prioridade,
                    DATAALTERACAO = @DataAlteracao,
                    ATIVO = @Ativo
                WHERE 
                    ID = @Id
            ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(query, obj);
            }

            
        }

        public void Delete(Evento obj)
        {
            var query = @"
                DELETE FROM EVENTO
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(query, obj);
            }

        }

        public List<Evento> GetAll()
        {
            var query = @"
                SELECT * FROM EVENTO
                ORDER BY DATA DESC, HORA DESC
            ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection
                    .Query<Evento>(query)
                    .ToList();
            }
        }

        public Evento? GetById(Guid id)
        {
            var query = @"
                SELECT * FROM EVENTO
                WHERE ID = @id
            ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection
                    .Query<Evento>(query, new { id })
                    .FirstOrDefault();
            }
        }

        public List<Evento> GetByDatas(DateTime? dataMin, DateTime? dataMax, int? ativo, Guid? IdUsuario)
        {
            var query = @"
                SELECT 
                       * 
                FROM 
                     EVENTO
                WHERE 
                     ATIVO = @ativo AND 
                     DATA BETWEEN @dataMin AND @dataMax AND 
                     IDUSUARIO = @IdUsuario
                ORDER BY DATA DESC, HORA DESC
            ";

            using (var connection = new SqlConnection(_connectionstring))
            {
                return connection
                    .Query<Evento>(query, new { ativo, dataMin, dataMax, IdUsuario })
                    .ToList();
            }
        }

      
    }
}
