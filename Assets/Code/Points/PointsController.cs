using System;
using Controllers;
using Interfaces;
using Interfaces.MVC;
using UnityEngine.UI;

namespace Points
{

    public class PointsController : IController, IRestartable, IDisposable
    {

        #region Fields

        private int _points;

        private Text _text;

        #endregion

        #region Observers

        private GameRestarter _gameRestarter;

        #endregion

        #region Constructors

        public PointsController(PointsView pointsView, GameRestarter gameRestarter)
        {

            _text           = pointsView.Text;

            _gameRestarter  = gameRestarter;
            
            _gameRestarter.AddHandler(Restart);

            Restart();

        }

        #endregion

        #region Interfaces Methods

        public void Restart()
        {

            NullifyPoints();

        }

        public void Dispose()
        {

            _gameRestarter.RemoveHandler(Restart);

        }

        #endregion

        #region Methods

        public void AddPoints(int points)
        {

            _points     += points;
            _text.text  = _points.ToString();
            
        }

        public void NullifyPoints()
        {

            _points     = 0;
            _text.text  = _points.ToString();
            
        }

        #endregion

    }

}