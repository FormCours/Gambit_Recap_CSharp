using Demo_07_IntroADO;
using Npgsql;
using System.Data;

// Package SQL pour PostgreSQL : Npgsql
// ConnectionString : https://www.connectionstrings.com/postgresql/

string connectionString = "Server=127.0.0.1;Port=5432;Database=GambitDB;User Id=postgres;Password=Test1234=;";

int CreateElement(NpgsqlConnection connection, string name, string? desc)
{
    using (NpgsqlCommand command = connection.CreateCommand())
    {
        // Définition de la query
        command.CommandText = "INSERT INTO \"DemoAdo\"(\"Name\", \"Desc\")" +
                                " VALUES (@name, @desc)" +
                                " RETURNING \"Id\";";

        // Ajout des parametres
        // - Directement via la méthode "AddWithValue"
        command.Parameters.AddWithValue("name", name);
        // - Si utilisation du pattern "facade" la méthode n'est pas dispo 😭
        IDataParameter paramDesc = command.CreateParameter();
        paramDesc.ParameterName = "desc";
        paramDesc.Value = desc as object ?? DBNull.Value; // Attention au valeur nullable
        command.Parameters.Add(paramDesc);

        // Execution de la requete
        int id = (int)command.ExecuteScalar()!;

        return id;
    }
}

IEnumerable<GambitExemple> GetElements(NpgsqlConnection connection)
{
    using NpgsqlCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM \"DemoAdo\"";

    using NpgsqlDataReader reader = command.ExecuteReader();
    while(reader.Read())
    {
        GambitExemple exemple = new GambitExemple()
        {
            //Id = reader.GetInt32(reader.GetOrdinal("Id"),
            //Id = Convert.ToInt32(reader["Id"]),
            Id = (int)reader["Id"],
            Name = (string)reader["Name"],
            Desc = reader["Desc"] is DBNull ? null : (string)reader["Desc"],
            IsActive = (bool)reader["IsActive"]
        };
        yield return exemple;
    }
}



// Utilisation
using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open();

    int elem1Id = CreateElement(connection, "Demo", "Exemple !!!");
    Console.WriteLine($"Element ajouté avec l'id : {elem1Id}");

    int elem2Id = CreateElement(connection, "Nullable", null);
    Console.WriteLine($"Element ajouté avec l'id : {elem2Id}");
    Console.WriteLine();

    Console.WriteLine("Liste des éléments : ");
    foreach (GambitExemple exemple in GetElements(connection))
    {
        Console.WriteLine($" - [{exemple.Id}] {exemple.Name} : {exemple.Desc ?? "N/A"}");
    }
}