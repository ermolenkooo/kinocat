using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.ModelsForDB;

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

        public IEnumerable<UserDB> GetUsers()
        {
            return database.Table<UserDB>().ToList();
        }
        public UserDB GetUser(int id)
        {
            return database.Get<UserDB>(id);
        }
        public int DeleteUser(int id)
        {
            return database.Delete<UserDB>(id);
        }
        public int SaveUser(UserDB item)
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

        public IEnumerable<FilmDB> GetFilms()
        {
            return database.Table<FilmDB>().ToList();
        }
        public FilmDB GetFilm(int id)
        {
            return database.Get<FilmDB>(id);
        }
        public int DeleteFilm(int id)
        {
            return database.Delete<FilmDB>(id);
        }
        public int SaveFilm(FilmDB item)
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

        public IEnumerable<FollowerDB> GetFollowers()
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

        public IEnumerable<LetterDB> GetLetters()
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

        public IEnumerable<LoveDB> GetLove()
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

        public IEnumerable<WatchlistDB> GetWatchlist()
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

        public IEnumerable<MarkDB> GetMarks()
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
