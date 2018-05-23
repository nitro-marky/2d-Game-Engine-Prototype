using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;

namespace Game_Prototype.Input
{

    //Entities that can be interacted with contain the input component which stores the states of input e.g if it has been clicked.
    class InputComponent : IInputComponent
    {
        private bool _isClickable;
        private bool _isHoverable;
        private bool _clicked;
        private bool _rightClicked;
        private bool _hover;
        private IEntity _parent;

        public InputComponent(IEntity entity)
        {
            _parent = entity;
        }


        public bool Clicked
        {
            get { return _clicked; }
            set { _clicked = value; }
        }

        public bool Hovering
        {
            get { return _hover; }
            set { _hover = value; }
        }


        public bool isClickable
        {
            get { return _isClickable; }
            set { _isClickable = value; }
        }

        public bool isHoverable
        {
            get { return _isHoverable; }
            set { _isHoverable = value; }
        }




        public bool RightClicked
        {
            get
            {
                return _rightClicked;
            }
            set
            {
                _rightClicked = value;
            }
        }
    }
}
