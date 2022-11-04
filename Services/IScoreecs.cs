using Score.Models;
using static ScoreServices.ScoreServices;

namespace Scoreee.Services
{
    public interface IScoreecs
    {
        public List<Scoree> Getscores();
        public Scoree getScorByid(int ScoreId);
        public List<ScoreList> PostScoree(ScoreList _scoree);
        public ResponseModel DeleteScore(int ScoreId);
    }
}
