using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Interfaces;
using Interfaces.MVC;
using Interfaces.MVC.UnityEvents;
using Interfaces.Quests;

using static Iterators.AdvancedIterators;

namespace Quests
{

    public class QuestController : IController, IQuestObjectsToggle, IRestartable, IUpdate, IDisposable
    {

        #region Fields

        private bool _completed;
        private QuestModel _model;
        private List<IQuestSubscriber> _subscribers;
        private LinkedList<IQuestTaskController> _tasks = new LinkedList<IQuestTaskController>();
        private LinkedListNode<IQuestTaskController> _currentTask;

        #endregion

        #region Observers

        private GameRestarter _gameRestarter;

        #endregion

        #region Interfaces Properties

        public bool Completed => _completed;
        public LinkedList<IQuestTaskController> Tasks => _tasks;
        public LinkedListNode<IQuestTaskController> CurrentTask => _currentTask;

        #endregion

        #region Properties

        private IQuestTaskController CurrentTaskController => _currentTask.Value;

        #endregion

        #region Constructors

        public QuestController(QuestModel model, List<IQuestSubscriber> subscribers, GameRestarter gameRestarter)
        {

            _model          = model;
            _subscribers    = subscribers;

            ExecuteLinearAction(model.Tasks.Count, (i) =>
            {

                var taskModel = model.Tasks[i];

                var questViews = new List<IQuestView>();

                ExecuteLinearAction(subscribers.Count, (j) =>
                {

                    questViews.AddRange(subscribers[j].QuestViews.Where((x) => taskModel.ID == x.ID).ToList());

                });

                _tasks.AddLast(
                    CreateTaskController(
                        taskModel,
                        questViews));

            });

            Restart();

            _gameRestarter = gameRestarter;
            _gameRestarter.AddHandler(Restart);

        }

        #endregion

        #region Interfaces Methods

        public void EnableQuestObjects(int id)
        {

            ExecuteLinearAction(_subscribers.Count, (i) =>
            {

                _subscribers[i].EnableQuestObjects(id);

            });

        }

        public void DisableQuestObjects(int id)
        {

            ExecuteLinearAction(_subscribers.Count, (i) =>
            {

                _subscribers[i].DisableQuestObjects(id);

            });
            
        }

        public void Restart()
        {

            _completed = false;
            _currentTask = _tasks.First;
            
            ExecuteLinearAction(_model.Tasks.Count, (i) =>
            {

                DisableQuestObjects(_model.Tasks[i].ID);

            });

            foreach(var taskControllerNode in _tasks)
            {

                taskControllerNode.Completed = false;

            };

            EnableQuestObjects(CurrentTaskController.ID);

        }

        public void OnUpdate(float deltaTime)
        {

            if (_currentTask == null) return;

            var currentTaskController = _currentTask.Value;
            
            if (currentTaskController is IUpdate updateTaskController)
            {

                updateTaskController.OnUpdate(deltaTime);

            };

            if (currentTaskController.Completed)
            {

                OnQuestTaskCompleted();

            };

        }

        public void Dispose()
        {

            _gameRestarter?.RemoveHandler(Restart);

        }

        #endregion

        #region Methods

        private IQuestTaskController CreateTaskController(QuestTaskModel taskModel, List<IQuestView> questViews)
        {

            if(taskModel.Type == QuestType.TriggerZones)
            {

                var questTriggerZones = new List<IQuestTriggerZone>();

                ExecuteLinearAction(questViews.Count, (i) =>
                {

                    if(questViews[i] is IQuestTriggerZone questTriggerZone)
                    {

                        questTriggerZones.Add(questTriggerZone);

                    };

                });

                return new QuestTaskTriggerZoneController(taskModel, questTriggerZones);

            }
            else
            {

                throw new Exception("Cannot construct Quest Task Controller. Quest type is undefined.");

            };

        }

        private void OnQuestTaskCompleted()
        {

            DisableQuestObjects(CurrentTaskController.ID);

            _currentTask = CurrentTask.Next;

            if (_currentTask == null)
            {

                _completed = true;

            }
            else
            {

                EnableQuestObjects(CurrentTaskController.ID);

            };

        }

        #endregion

    }

}