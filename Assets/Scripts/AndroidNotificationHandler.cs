using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;
using UnityEngine.Android;

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    private const string ChannelId = "notification_channel";

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }
    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        { 
            Id = ChannelId,
            Name = "Notification Channel",
            Description = "Random desc",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification androidNotification = new AndroidNotification
        {
            Title = "Energy recharged!",
            Text = "Your energy has recharged, come back and play!",
            SmallIcon = "Default",
            LargeIcon = "Default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(androidNotification, ChannelId);
    }
#endif
}
