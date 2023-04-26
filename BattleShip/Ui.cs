// File:    Ui.cs
// Author:  nilov_pg
// Created: 10 июля 2020 г. 11:10:44
// Purpose: Definition of Interface Ui

using System;

namespace BattleShip
{
    abstract public class Ui
    {
        protected Field firstField;
        protected Field secondField;
        abstract public void Update();
        public void SetFirstField(Field firstPlayerField)
        {
            this.firstField = firstPlayerField;
        }
        public void SetSecondField(Field secondPlayerField)
        {
            this.secondField = secondPlayerField;
        }
    }
}