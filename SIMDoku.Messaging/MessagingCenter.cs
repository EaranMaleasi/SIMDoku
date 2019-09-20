using System;
using System.Collections.Generic;

namespace SIMDoku.Messaging
{
	public class MessagingCenter : IMessagingCenter
	{
		private readonly Dictionary<string, Dictionary<object, Action>> _NotificationSubscriber;
		private readonly Dictionary<string, Dictionary<object, Action<object>>> _MessageSubscriber;

		public MessagingCenter()
		{
			_NotificationSubscriber = new Dictionary<string, Dictionary<object, Action>>();
			_MessageSubscriber = new Dictionary<string, Dictionary<object, Action<object>>>();
		}

		public void SubscribeTo(string message, object subscriber, Action handler)
		{
			if (_NotificationSubscriber.ContainsKey(message))
			{
				_NotificationSubscriber[message][subscriber] = handler;
			}
			else
			{
				_NotificationSubscriber[message] = new Dictionary<object, Action>() { { subscriber, handler } };
			}
		}

		public void SubscribeTo<T>(string message, object subscriber, Action<T> handler)
		{
			if (_MessageSubscriber.ContainsKey(message))
			{
				_MessageSubscriber[message][subscriber] = handler as Action<object>;
			}
			else
			{
				_MessageSubscriber[message] = new Dictionary<object, Action<object>>() { { subscriber, handler as Action<object> } };
			}
		}

		public void UnsubscribeFrom(string message, object subscriber)
		{
			if (_NotificationSubscriber.ContainsKey(message))
			{
				_NotificationSubscriber[message].Remove(subscriber);
			}
		}

		public void SendNotification(string message)
		{
			foreach (Action handler in _NotificationSubscriber[message].Values)
			{
				handler.Invoke();
			}
		}

		public void SendMessage<T>(string message, T data)
		{
			foreach (Action<object> item in _MessageSubscriber[message].Values)
			{
				if (item is Action<T> handler)
				{
					handler.Invoke(data);
				}
			}
		}
	}
}
