﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace HFSM.StateMachine
{
    public abstract class StateMachine<T> : MonoBehaviour where T : StateMachine<T>
    {
        private StateFactory<T> stateFactory;
        private List<State<T>> currentStatePath = new List<State<T>>();

        private void Start()
        {
            stateFactory = new StateFactory<T>(this as T);
            SetInitialState();
        }

        private void FixedUpdate()
        {
            foreach (State<T> state in currentStatePath)
                state?.FixedUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
            foreach (State<T> state in currentStatePath)
                state?.OnTriggerEnter(other);
        }

        protected abstract void SetInitialState();

        #region State Update

        public void SetState<TState>() where TState : State<T>
        {
            State<T> newState = stateFactory.GetState<TState>();
            List<State<T>> newStatePath = stateFactory.GetStatePath(newState);

            ExitOldStates(newStatePath);
            EnterNewStates(newStatePath);

            currentStatePath = newStatePath;
        }

        private void EnterNewStates(List<State<T>> newStatePath)
        {
            for (int index = newStatePath.Count - 1; index >= 0; index--)
            {
                State<T> newStateInPath = newStatePath[index];
                
                if (!currentStatePath.Contains(newStateInPath))
                    newStateInPath?.EnterState();
            }
        }

        private void ExitOldStates(List<State<T>> newStatePath)
        {
            foreach (State<T> oldStateInPath in currentStatePath)
            {
                if (!newStatePath.Contains(oldStateInPath))
                    oldStateInPath?.ExitState();
            }
        }
        
        #endregion
    }
}
