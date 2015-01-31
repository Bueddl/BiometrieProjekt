﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace YoloTrack.MVC.Model.StateMachine.Impl
{
    class TrackingDecisionImpl : BaseImpl<Arg.TrackingDecisionArg>
    {
        public override void Run(Arg.TrackingDecisionArg arg)
        {
            Storage.Person matched = Model.MainDatabase.People.Find(p => p.Id == arg.PersonId);

            if (matched.IsTarget)
            {
                matched.TrackedCount++;
                Model.MainDatabase.Update(matched);

                Result = new Arg.TrackingArg()
                {
                    SkeletonId = matched.RuntimeInfo.SkeletonId
                };
            }
            else
            {
                Result = new Arg.WaitForBodyArg();
            }
        }
    }
}
