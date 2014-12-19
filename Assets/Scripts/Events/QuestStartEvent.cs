using System;
using System.Collections.Generic;

public class QuestStartEvent {

	public interface Condition {
		bool On(QuestStartEvent e);
	}

	public interface Action {
		void On(QuestStartEvent e);
	}
	
	public Quest quest;
}
