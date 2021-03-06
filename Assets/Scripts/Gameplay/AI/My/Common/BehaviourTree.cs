using System.Collections.Generic;

namespace Tools.BehaviourTree {

    public class BehaviourTree : Task {

        public List<Task> Tasks { get; private set; }
        public Blackboard Blackboard { get; set; }
        public BehaviourTreeExecutor Executor { get; set; }

        public BehaviourTree() : base() {
            BehaviourTree = this;
            Tasks = new List<Task>();
        }

        public override void Init() {
        }

        public override void Begin() {
        }

        public override TaskStatus Run() {
            return Children[0].UpdateTask();
        }

        public void RegisterTask(Task task) {
            Tasks.Add(task);
        }
    }
}
