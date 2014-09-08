﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetMQ.Actors;
using NUnit.Framework;

namespace NetMQ.Tests.InProcActors.Echo
{
    [TestFixture]
    public class EchoActorTests
    {
        [TestCase("I like NetMQ")]
        [TestCase("NetMQ Is quite awesome")]
        [TestCase("Agreed sockets on steroids with isotopes")]
        public void EchoActorSendReceiveTests(string actorMessage)
        {
            EchoShimHandler echoShimHandler = new EchoShimHandler();
            Actor actor = new Actor(NetMQContext.Create(), echoShimHandler, new object[] { "Hello World" });
            actor.SendMore("ECHO");
            actor.Send(actorMessage);
            var result = actor.ReceiveString();
            string expectedEchoHandlerResult = string.Format("ECHO BACK : {0}", actorMessage);
            Assert.AreEqual(expectedEchoHandlerResult, result);
            actor.Dispose();            
        }

        //[TestCase("One")]
        ////[ExpectedException(typeof(NetMQException))]
        //public void ExceptionIsRaisedWhenTryingToUseDisposedActor(string actorMessage)
        //{
        //    EchoShimHandler echoShimHandler = new EchoShimHandler();
        //    Actor actor = new Actor(NetMQContext.Create(), echoShimHandler, new object[] { "Hello World" });
        //    actor.SendMore("ECHO");
        //    actor.Send(actorMessage);
        //    var result = actor.ReceiveString();
        //    string expectedEchoHandlerResult = string.Format("ECHO BACK : {0}", actorMessage);
        //    Assert.AreEqual(expectedEchoHandlerResult, result);
        //    actor.Dispose();
        //    GC.WaitForPendingFinalizers();
          


        //    //should not work, as Actor was just disposed
        //    actor.SendMore("ECHO");
        //    actor.Send(actorMessage);
        //    result = actor.ReceiveString();
        //    Assert.AreEqual(typeof(NetMQException), actor.Exception.GetType());
            
        //}
  
    }
}
