﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoloTrack.MVC.Model.Storage
{
    public class MainDatabase
    {
        public event EventHandler PersonAdded;
        public event EventHandler PersonRemoved;

        public void OnPersonAdded()
        {
            if (PersonAdded == null)
                return;

            PersonAdded(this, new EventArgs());
        }

        public void OnPersonRemoved()
        {
            if (PersonRemoved == null)
                return;

            PersonRemoved(this, new EventArgs());
        }

        private List<Person> m_people;

        public List<Person> People
        {
            get { return m_people; }
        }

        public Person Target
        {
            get {
                return m_people.Find(p => p.IsTarget == true);
            }
            set {
                // LoL
                Person benis = m_people.Find(p => p.IsTarget == true);
                benis.IsTarget = false;
                benis = m_people.Find(p => p.Equals(value));
                benis.IsTarget = true;
                // ^^------------------ dat Code
                /*/
                 
                                ROFL ROFL LOL ROFL ROFL
                                   ________/\_______
                               L   \             \  \
                              LOL===\ [][][][][]  \__\
                               L     \                \
                                      \________________]
                                       __||_________||___/
              
               /*/
            }
        }

        public void Add(Person p)
        {
            m_people.Add(p);
            OnPersonAdded();
        }

        public void Remove(Predicate<Person> pre)
        {
            m_people.Remove(m_people.Find(pre));
            OnPersonRemoved();
        }
    }
}