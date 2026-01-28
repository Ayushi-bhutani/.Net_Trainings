using System.Collections.Generic;
using AgendaBuilder.Models;
using AgendaBuilder.Utils;

namespace AgendaBuilder.Services {
    public class AgendaPlanner {
        public void AssignSessions (
            List <Preference> preferences,
            Dictionary<string, Session > sessions,
            Dictionary<string, ConferenceDelegate> delegates,
            Dictionary<string, Venue> venues,
            int maxTravelTime
        )

        {
            preferences.Sort((a,b) => b.Score.CompareTo(a.Score));
            foreach ( var pref in preferences ){
                Session session = sessions[pref.SessionId];
                ConferenceDelegate del = delegates[pref.DelegateId];

                if(session.UsedCapacity >= session.Capacity){
                    continue;
                }
                if(!CanAssign(del, session, venues, maxTravelTime))
                    continue;
                del.AssignedSessions.Add(session);
                session.UsedCapacity++;

            }
        

    }


    private bool CanAssign(
        ConferenceDelegate del,
        Session newSession ,
        Dictionary<string, Venue> venues,
        int maxTravelTime
    )
    {
    foreach (var assigned in del.AssignedSessions){
        if(Helper.IsOverlap(assigned, newSession))
            return false;
        
        Venue v1 = venues[assigned.VenueId];
        Venue v2 = venues[newSession.VenueId];

        if(Helper.Distance(v1, v2) > maxTravelTime)
            return false;
    }
    return true;
    }
  }
}