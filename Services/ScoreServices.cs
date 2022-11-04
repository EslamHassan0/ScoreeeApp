using Score.Models;
using Scoreee.Services;
using System;
using System.Collections.Generic;

namespace ScoreServices
{
    public class ScoreServices : IScoreecs
    {
        private readonly newScoreContext _scoreContext;
        public ScoreServices(newScoreContext scoreContext)
        {
            _scoreContext = scoreContext;   
        }
        public List<Scoree> Getscores()
        {
            List<Scoree> scores;
            try
            {
                scores = _scoreContext.Set<Scoree>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return scores;  
        }
        public Scoree getScorByid(int ScoreId)
        {
            Scoree scoree;
            try
            {
                scoree = _scoreContext.Find<Scoree>(ScoreId);

            }
            catch (Exception)
            {

                throw;
            }
            return scoree;
        }
        public class ScoreList
        {
            public int ScoreId { get; set; }
            public string Clubname { get; set; } = null!;
            public string PlanyerName { get; set; } = null!;
            public int ScRight { get; set; }
            public int ScLeft { get; set; }
            public int Forehand { get; set; }
            public int Backhand { get; set; }
            public int Total { get; set; }
            public string? Notes { get; set; }
        }
        public List<ScoreList> PostScoree(ScoreList _scoree)
        {
            Scoree scoree = null;
            try
            {
                if (_scoree.ScoreId!=0)
                {
                    scoree.Forehand = _scoree.Forehand;
                    scoree.ScLeft = _scoree.ScLeft;
                    scoree.ScRight = _scoree.ScRight;
                    scoree.Total = _scoree.Total;
                    scoree.Notes = _scoree.Notes;
                    scoree.Backhand = _scoree.Backhand;
                    scoree.Clubname = _scoree.Clubname;
                    scoree.PlanyerName = _scoree.PlanyerName;
                    _scoreContext.Update<Scoree>(scoree);
                }
                else
                {
                    scoree = new Scoree();
                    scoree.Forehand = _scoree.Forehand;
                    scoree.ScLeft = _scoree.ScLeft;
                    scoree.ScRight = _scoree.ScRight;
                    scoree.Total = _scoree.Total;
                    scoree.Notes = _scoree.Notes;
                    scoree.Backhand = _scoree.Backhand;
                    scoree.Clubname = _scoree.Clubname;
                    scoree.PlanyerName = _scoree.PlanyerName;
                    _scoreContext.Add<Scoree>(scoree);  
                }
                _scoreContext.SaveChanges();
                return _scoreContext.Scores
                    .Select(s => new ScoreList
                    {
                        ScLeft = s.ScLeft,
                        ScRight = s.ScRight,
                        Total = s.Total,
                        Notes = s.Notes,
                        Backhand = s.Backhand,
                        Clubname = s.Clubname,
                        PlanyerName = s.PlanyerName,
                        Forehand = s.Forehand,

                    }).ToList();
                
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ResponseModel DeleteScore(int ScoreId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Scoree _scoree = getScorByid(ScoreId);
                _scoreContext.Remove<Scoree>(_scoree);
                _scoreContext.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "DeleteCompany Successfully";

            }
            catch (Exception)
            {

                throw;
            }
            return model;
        }

    }
}
