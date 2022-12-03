using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.ModelsForDB;
using SQLiteNetExtensions.Extensions;

namespace App1.ModelsForDB
{
    public class ContextDB
    {
        SQLiteConnection database;
        public ContextDB(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<UserDB>();
            database.CreateTable<FilmDB>();
            database.CreateTable<FollowerDB>();
            database.CreateTable<LetterDB>();
            database.CreateTable<LoveDB>();
            database.CreateTable<WatchlistDB>();
            database.CreateTable<MarkDB>();
        }

        public List<UserDB> GetUsers()
        {
            return database.GetAllWithChildren<UserDB>();
            //return database.Table<UserDB>().ToList();
        }
        public UserDB GetUser(int id)
        {
            return database.GetWithChildren<UserDB>(id);
            //return database.Get<UserDB>(id);
        }
        public int DeleteUser(int id)
        {
            return database.Delete<UserDB>(id);
        }
        public void SaveUser(UserDB item)
        {
            if (item.Id != 0)
            {
                database.UpdateWithChildren(item);
                //database.Update(item);
                //return item.Id;
            }
            else
            {
                database.InsertWithChildren(item);
                //return database.Insert(item);
            }
        }

        public List<FilmDB> GetFilms()
        {
            return database.GetAllWithChildren<FilmDB>();
            //return database.Table<FilmDB>().ToList();
        }
        public FilmDB GetFilm(int id)
        {
            return database.GetWithChildren<FilmDB>(id);
            //return database.Get<FilmDB>(id);
        }
        public int DeleteFilm(int id)
        {
            return database.Delete<FilmDB>(id);
        }
        public void SaveFilm(FilmDB item)
        {
            if (item.Id != 0)
            {
                //database.Update(item);
                database.UpdateWithChildren(item);
                //return item.Id;
            }
            else
            {
                database.InsertWithChildren(item);
                //database.Insert(item);
            }
        }

        public List<FollowerDB> GetFollowers()
        {
            return database.Table<FollowerDB>().ToList();
        }
        public FollowerDB GetFollower(int id)
        {
            return database.Get<FollowerDB>(id);
        }
        public int DeleteFollower(int id)
        {
            return database.Delete<FollowerDB>(id);
        }
        public int SaveFollower(FollowerDB item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public List<LetterDB> GetLetters()
        {
            return database.Table<LetterDB>().ToList();
        }
        public LetterDB GetLetter(int id)
        {
            return database.Get<LetterDB>(id);
        }
        public int DeleteLetter(int id)
        {
            return database.Delete<LetterDB>(id);
        }
        public int SaveLetter(LetterDB item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public List<LoveDB> GetLove()
        {
            return database.Table<LoveDB>().ToList();
        }
        public LoveDB GetLove(int id)
        {
            return database.Get<LoveDB>(id);
        }
        public int DeleteLove(int id)
        {
            return database.Delete<LoveDB>(id);
        }
        public int SaveLove(LoveDB item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public List<WatchlistDB> GetWatchlist()
        {
            return database.Table<WatchlistDB>().ToList();
        }
        public WatchlistDB GetWatchlist(int id)
        {
            return database.Get<WatchlistDB>(id);
        }
        public int DeleteWatchlist(int id)
        {
            return database.Delete<WatchlistDB>(id);
        }
        public int SaveWatchlist(WatchlistDB item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public List<MarkDB> GetMarks()
        {
            return database.Table<MarkDB>().ToList();
        }
        public MarkDB GetMark(int id)
        {
            return database.Get<MarkDB>(id);
        }
        public int DeleteMark(int id)
        {
            return database.Delete<MarkDB>(id);
        }
        public int SaveMark(MarkDB item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
