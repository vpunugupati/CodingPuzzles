﻿using ConferenceEventPlanner;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConferenceEventPlanner.Tests
{
    [TestClass()]
    public class ConferencePlannerTests
    {
        [TestMethod()]
        public void GenerateConferencePlanWithFirstFitDecreasingSchedulerTest()
        {
            var inputReaderMock = new Mock<IInputReader>(MockBehavior.Strict);

            var outputWriterMock = new Mock<IOutputWriter>(MockBehavior.Strict);           
            var conferencePlanner = new ConferencePlanner(inputReaderMock.Object, new FirstFitDecreasingScheduler(), outputWriterMock.Object);

            var testinput = new List<string>{"EUV Catch me if you Can (Home Expert) 30 min",
                                            "Wonder Defects and Where to find them? (Home Expert) 75 min",
                                            "Architecting the Intelligent Apps Engineer(Vignette)",
                                            "Quantum Entangled Inspection(Home Expert) 70 min",
                                            "Tesla’s Legacy(Vignette)",
                                            "Quantum Revolution by Super Clean Reticles(Home Expert) 60 min",
                                            "Q#ing to Entropy Modeling (Home Expert) 45 min",
                                            "Geek’s Life(Vignette)",
                                            "BBP – Speed I am Speed(Home Expert) 45 min",
                                            "What is a bug ? – Test Driving to a Bug Free Universe(Home Expert) 90 min",
                                            "Git your Rational Team Concert out of here(Home Expert) 35 min",
                                            "Future of Particle Imaging with Muons(Vignette)",
                                            "Continuous Delivery in a Disconnected Environment(Home Expert) 85 min",
                                            "Atomic Transistors->Super Computing in your Palm(5 min)",
                                            "eBeam Wafer Inspection – Saves the Day(Home Expert) 60 min",
                                            "Up for a real challenge - beyond the world of Mobile Apps(Vignette)",
                                            "What if Tesla was lucky enough to work for us ? (Vignette)",
                                            "Quantum Revolution by Super Clean Reticles(Home Expert) 25 min",
                                            "Quantum Machine Learning(Home Expert) 60 min",
                                            "Defect Location Accuracy at the Atomic Level(Home Expert) 60 min",
                                            "Timing the Photon Pulse(Vignette)"
                                            };
            inputReaderMock.Setup(s => s.GetEventsData()).Returns(() => { return testinput; });

            outputWriterMock.Setup(s => s.Write(It.IsAny<string>())).Callback<string>((plan) => { if (Regex.Matches(plan, "Track").Count != 2) Assert.Fail(); });

            conferencePlanner.GenerateConferencePlan();
            
        }

        [TestMethod()]
        public void GenerateConferencePlanWithBestFitDecreasingSchedulerTest()
        {
            var inputReaderMock = new Mock<IInputReader>(MockBehavior.Strict);

            var outputWriterMock = new Mock<IOutputWriter>(MockBehavior.Strict);
            var conferencePlanner = new ConferencePlanner(inputReaderMock.Object, new BestFitDecreasingScheduler(), outputWriterMock.Object);

            var testinput = new List<string>{"EUV Catch me if you Can (Home Expert) 30 min",
                                            "Wonder Defects and Where to find them? (Home Expert) 75 min",
                                            "Architecting the Intelligent Apps Engineer(Vignette)",
                                            "Quantum Entangled Inspection(Home Expert) 70 min",
                                            "Tesla’s Legacy(Vignette)",
                                            "Quantum Revolution by Super Clean Reticles(Home Expert) 60 min",
                                            "Q#ing to Entropy Modeling (Home Expert) 45 min",
                                            "Geek’s Life(Vignette)",
                                            "BBP – Speed I am Speed(Home Expert) 45 min",
                                            "What is a bug ? – Test Driving to a Bug Free Universe(Home Expert) 90 min",
                                            "Git your Rational Team Concert out of here(Home Expert) 35 min",
                                            "Future of Particle Imaging with Muons(Vignette)",
                                            "Continuous Delivery in a Disconnected Environment(Home Expert) 85 min",
                                            "Atomic Transistors->Super Computing in your Palm(5 min)",
                                            "eBeam Wafer Inspection – Saves the Day(Home Expert) 60 min",
                                            "Up for a real challenge - beyond the world of Mobile Apps(Vignette)",
                                            "What if Tesla was lucky enough to work for us ? (Vignette)",
                                            "Quantum Revolution by Super Clean Reticles(Home Expert) 25 min",
                                            "Quantum Machine Learning(Home Expert) 60 min",
                                            "Defect Location Accuracy at the Atomic Level(Home Expert) 60 min",
                                            "Timing the Photon Pulse(Vignette)"
                                            };
            inputReaderMock.Setup(s => s.GetEventsData()).Returns(() => { return testinput; });

            outputWriterMock.Setup(s => s.Write(It.IsAny<string>())).Callback<string>((plan) => { if (Regex.Matches(plan, "Track").Count != 2) Assert.Fail(); });

            conferencePlanner.GenerateConferencePlan();

        }



    }
}
