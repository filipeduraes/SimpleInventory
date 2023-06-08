using System;
using System.Collections;
using UnityEngine;

namespace HFSM.StateMachine
{
    public abstract class State<T> where T : StateMachine<T>
    {
        public virtual Type ParentState => null;

        protected T stateMachine;

        public State(T fsm)
        {
            stateMachine = fsm;
        }
        
        #region State Updates
        
        public virtual void EnterState() { }
        
        public virtual void FixedUpdate() { }
        
        public virtual void ExitState() { }
        
        
        public virtual void OnTriggerEnter(Collider other) { }
        
        #endregion

        #region Help Methods

        protected void SetState<TState>() where TState : State<T>
        {
            stateMachine.SetState<TState>();
        }

        protected Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return stateMachine.StartCoroutine(coroutine);
        }

        protected void StopCoroutine(Coroutine coroutine)
        {
            stateMachine.StopCoroutine(coroutine);
        }
        
        #endregion
    }
}
