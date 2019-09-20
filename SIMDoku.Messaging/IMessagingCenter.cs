using System;

namespace SIMDoku.Messaging
{
	public interface IMessagingCenter
	{
		void SendMessage<T>(string message, T data);
		void SendNotification(string message);
		void SubscribeTo(string message, object subscriber, Action handler);
		void SubscribeTo<T>(string message, object subscriber, Action<T> handler);
		void UnsubscribeFrom(string message, object subscriber);
	}
}