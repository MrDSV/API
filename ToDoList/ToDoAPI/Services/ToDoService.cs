using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Models.ToDoList;

namespace ToDoAPI.Services
{
    public class ToDoService
    {
        private readonly IMongoCollection<ToDo> todo;

        public ToDoService(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ToDoStoreDb");
            todo = database.GetCollection<ToDo>(collectionName);
        }

        public List<ToDo> Get()
        {
            return todo.Find(todoA => true).ToList();
        }

        public ToDo Get(int id)
        {
            return todo.Find<ToDo>(todoA => todoA.Id == id).FirstOrDefault();
        }

        public ToDo Create(ToDo todoA)
        {
            todo.InsertOne(todoA);
            return todoA;
        }

        public void Update(int id, ToDo todoNew)
        {
            todo.ReplaceOne(todoA => todoA.Id == id,todoNew);
        }

        public void Remove(ToDo todoRequest)
        {
            todo.DeleteOne(todoA => todoA.Id == todoRequest.Id);
        }

        public void Remove(int id)
        {
            todo.DeleteOne(todoA => todoA.Id == id);
        }
    }
}
