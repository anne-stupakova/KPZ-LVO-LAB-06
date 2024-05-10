﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CheckersGame
{
    public partial class PrototypeCheckerGame : Form
    {
        const int MapSize = 8;
        const int CageSize = 50;

        int currentPlayer;

        List<Button> simpleSteps = new List<Button>();

        int countEatSteps = 0;
        Button prevButton;
        Button pressedButton;
        bool isContinue = false;

        bool isMoving;

        int[,] map = new int[MapSize, MapSize];

        Button[,] buttons = new Button[MapSize, MapSize];

        Image UpFigure = Properties.Resources.white.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero);
        Image DownFigure = Properties.Resources.black.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero);

        private CheckerColorManager colorManager;

        public PrototypeCheckerGame()
        {
            InitializeComponent();

            Image whiteDefault = Properties.Resources.white.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero);
            Image blackDefault = Properties.Resources.black.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero);

            colorManager = new CheckerColorManager(whiteDefault, blackDefault);

            UPColorCB.SelectedIndexChanged += ColorCB_SelectedIndexChanged;
            DOWNColorCB.SelectedIndexChanged += ColorCB_SelectedIndexChanged;

            Initialization();
        }

        // Сhecker color change
        private void ColorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            Dictionary<string, Image> imageDictionary = new Dictionary<string, Image>
            {
                { "White", Properties.Resources.white.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero) },
                { "Black", Properties.Resources.black.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero) },
                
                { "Blue", Properties.Resources.blue.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero) },
                { "Yellow", Properties.Resources.yellow.GetThumbnailImage(CageSize - 10, CageSize - 10, null, IntPtr.Zero) }
            };

            Image selectedImage;
            if (imageDictionary.TryGetValue(cb.SelectedItem.ToString(), out selectedImage))
            {
                if (cb == UPColorCB)
                {
                    colorManager.WhiteFigure = selectedImage;
                }
                else if (cb == DOWNColorCB)
                {
                    colorManager.BlackFigure = selectedImage;
                }

                for (int i = 0; i < MapSize; i++)
                {
                    for (int j = 0; j < MapSize; j++)
                    {
                        int player = map[i, j];
                        if (player == 1 && cb == UPColorCB || player == 2 && cb == DOWNColorCB)
                        {
                            colorManager.UpdateButtonImage(buttons[i, j], player);
                        }
                    }
                }
            }
        }


        // Mechanics of counting the number of remaining checkers
        public int CountCheckers(int player)
        {
            int count = 0;
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (map[i, j] == player)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public void UpdateCheckersCountLabels()
        {
            int whiteCheckersCount = CountCheckers(1);
            int blackCheckersCount = CountCheckers(2);

            UpperLabel.Text = $"Player 1: {whiteCheckersCount}";
            LowerLabel.Text = $"Player 2: {blackCheckersCount}";
        }




        // Methods for rendering
        public void Initialization()
        {
            currentPlayer = 1;
            isMoving = false;
            prevButton = null;

            map = new int[MapSize, MapSize] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };

            CreateMap();
        }
        public void ResetGame()
        {
            bool player1 = false;
            bool player2 = false;

            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (map[i, j] == 1)
                        player1 = true;
                    if (map[i, j] == 2)
                        player2 = true;
                }
            }
            if (!player1 || !player2)
            {
                this.Controls.Clear();
                Initialization();
            }
        }
        public void CreateMap()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * CageSize, i * CageSize);
                    button.Size = new Size(CageSize, CageSize);
                    button.Click += new EventHandler(OnFigurePress);
                    if (map[i, j] == 1)
                        button.Image = UpFigure;
                    else if (map[i, j] == 2) button.Image = DownFigure;

                    button.BackColor = GetPrevButtonColor(button);
                    button.ForeColor = Color.Red;

                    buttons[i, j] = button;

                    this.Controls.Add(button);
                }
            }
        }
        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            ResetGame();
        }
        public Color GetPrevButtonColor(Button prevButton)
        {
            if ((prevButton.Location.Y / CageSize % 2) != 0)
            {
                if ((prevButton.Location.X / CageSize % 2) == 0)
                {
                    return Color.Gray;
                }
            }
            if ((prevButton.Location.Y / CageSize) % 2 == 0)
            {
                if ((prevButton.Location.X / CageSize) % 2 != 0)
                {
                    return Color.Gray;
                }
            }
            return Color.White;
        }


        // Handler of the event of pressing on the figure
        public void OnFigurePress(object sender, EventArgs e)
        {
            if (prevButton != null)
                prevButton.BackColor = GetPrevButtonColor(prevButton);

            pressedButton = sender as Button;

            if (IsValidPress())
            {
                HandleValidPress();
            }
            else
            {
                HandleInvalidPress();
            }

            prevButton = pressedButton;
        }
        private bool IsValidPress()
        {
            return (pressedButton != null &&
                    map[pressedButton.Location.Y / CageSize, pressedButton.Location.X / CageSize] == currentPlayer);
        }
        private void HandleValidPress()
        {
            CloseSteps();
            pressedButton.BackColor = Color.Red;
            DeactivateAllButtons();
            pressedButton.Enabled = true;
            countEatSteps = 0;
            if (pressedButton.Text == "👑")
                ShowStepsWay(pressedButton.Location.Y / CageSize, pressedButton.Location.X / CageSize, false);
            else
                ShowStepsWay(pressedButton.Location.Y / CageSize, pressedButton.Location.X / CageSize);

            if (isMoving)
            {
                CloseSteps();
                pressedButton.BackColor = GetPrevButtonColor(pressedButton);
                ShowPossibleSteps();
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
        }
        private void HandleInvalidPress()
        {
            if (isMoving)
            {
                isContinue = false;
                if (Math.Abs(pressedButton.Location.X / CageSize - prevButton.Location.X / CageSize) > 1)
                {
                    isContinue = true;
                    DeleteFallenChekers(pressedButton, prevButton);
                }
                MoveButtons();
            }
        }
        private void MoveButtons()
        {
            int temp = map[pressedButton.Location.Y / CageSize, pressedButton.Location.X / CageSize];
            map[pressedButton.Location.Y / CageSize, pressedButton.Location.X / CageSize] = map[prevButton.Location.Y / CageSize, prevButton.Location.X / CageSize];
            map[prevButton.Location.Y / CageSize, prevButton.Location.X / CageSize] = temp;
            pressedButton.Image = prevButton.Image;
            prevButton.Image = null;
            pressedButton.Text = prevButton.Text;
            prevButton.Text = "";
            DamkaModActivated(pressedButton);
            countEatSteps = 0;
            isMoving = false;
            CloseSteps();
            DeactivateAllButtons();
            HandleContinuation();
            UpdateCheckersCountLabels();
        }
        private void HandleContinuation()
        {
            if (countEatSteps == 0 || !isContinue)
            {
                CloseSteps();
                SwitchPlayer();
                ShowPossibleSteps();
                isContinue = false;
            }
            else if (isContinue)
            {
                pressedButton.BackColor = Color.Red;
                pressedButton.Enabled = true;
                isMoving = true;
            }
        }

        // Displays possible moves
        public void ShowStepsWay(int iCurrFigure, int jCurrFigure,bool isOnestep = true)
        {
            simpleSteps.Clear();
            ShowDiagonalWay(iCurrFigure, jCurrFigure,isOnestep);
            if (countEatSteps > 0)
                CloseSimpleSteps(simpleSteps);
        }
        public void ShowDiagonalWay(int IcurrFigure, int currentFigureColumn, bool isOneStep = false)
        {
            ShowDiagonalWayUpRight(IcurrFigure, currentFigureColumn, isOneStep);
            ShowDiagonalWayUpLeft(IcurrFigure, currentFigureColumn, isOneStep);
            ShowDiagonalWayDownLeft(IcurrFigure, currentFigureColumn, isOneStep);
            ShowDiagonalWayDownRight(IcurrFigure, currentFigureColumn, isOneStep);
        }
        private void ShowDiagonalWayUpRight(int currentFigureRow, int currentFigureColumn, bool isOneStep)
        {
            int j = currentFigureColumn + 1;
            for (int i = currentFigureRow - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }
        private void ShowDiagonalWayUpLeft(int currentFigureRow, int currentFigureColumn, bool isOneStep)
        {
            int j = currentFigureColumn - 1;
            for (int i = currentFigureRow - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }
        }
        private void ShowDiagonalWayDownLeft(int currentFigureRow, int currentFigureColumn, bool isOneStep)
        {
            int j = currentFigureColumn - 1;
            for (int i = currentFigureRow + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }
        }
        private void ShowDiagonalWayDownRight(int currentFigureRow, int currentFigureColumn, bool isOneStep)
        {
            int j = currentFigureColumn + 1;
            for (int i = currentFigureRow + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }
        public void ShowProceduralDead(int i,int j,bool isOneStep = true)
        {
            int dirX = i - pressedButton.Location.Y / CageSize;
            int dirY = j - pressedButton.Location.X / CageSize;
            dirX = dirX < 0 ? -1 : 1;
            dirY = dirY < 0 ? -1 : 1;
            int il = i;
            int jl = j;
            bool isEmpty = true;
            while (IsInsideBorders(il, jl))
            {
                if (map[il, jl] != 0 && map[il, jl] != currentPlayer)
                { 
                    isEmpty = false;
                    break;
                }
                il += dirX;
                jl += dirY;

                if (isOneStep)
                    break;
            }
            if (isEmpty)
                return;
            List<Button> toClose = new List<Button>();
            bool closeSimple = false;
            int ik = il + dirX;
            int jk = jl + dirY;
            while (IsInsideBorders(ik,jk))
            {
                if (map[ik, jk] == 0 )
                {
                    if (IsButtonHasDeleteStep(ik, jk, isOneStep, new int[2] { dirX, dirY }))
                    {
                        closeSimple = true;
                    }
                    else
                    {
                        toClose.Add(buttons[ik, jk]);
                    }
                    buttons[ik, jk].BackColor = Color.Yellow;
                    buttons[ik, jk].Enabled = true;
                    countEatSteps++;
                }
                else break;
                if (isOneStep)
                    break;
                jk += dirY;
                ik += dirX;
            }
            if (closeSimple && toClose.Count > 0)
            {
                CloseSimpleSteps(toClose);
            }
            
        }
        public void ShowPossibleSteps()
        {
            bool isOneStep = true;
            bool isEatStep = false;
            DeactivateAllButtons();
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (map[i, j] == currentPlayer)
                    {
                        if (buttons[i, j].Text == "👑")
                            isOneStep = false;
                        else isOneStep = true;
                        if (IsButtonHasDeleteStep(i, j, isOneStep, new int[2] { 0, 0 }))
                        {
                            isEatStep = true;
                            buttons[i, j].Enabled = true;
                        }
                    }
                }
            }
            if (!isEatStep)
                ActivateAllButtons();
        }

        // Closes possible moves
        public void CloseSteps()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    buttons[i, j].BackColor = GetPrevButtonColor(buttons[i, j]);
                }
            }
        }
        public void CloseSimpleSteps(List<Button> simpleSteps)
        {
            if (simpleSteps.Count > 0)
            {
                for (int i = 0; i < simpleSteps.Count; i++)
                {
                    simpleSteps[i].BackColor = GetPrevButtonColor(simpleSteps[i]);
                    simpleSteps[i].Enabled = false;
                }
            }
        }

        // Checks if there are possible moves with eating pieces.
        public bool IsButtonHasDeleteStep(int IcurrFigure, int currentFigureColumn, bool isOneStep, int[] dir)
        {
            bool deleteStep = false;

            deleteStep = CheckDirection(IcurrFigure, currentFigureColumn, isOneStep, dir, 1, -1);
            deleteStep |= CheckDirection(IcurrFigure, currentFigureColumn , isOneStep, dir, 1, 1);
            deleteStep |= CheckDirection(IcurrFigure, currentFigureColumn, isOneStep, dir, -1, 1);
            deleteStep |= CheckDirection(IcurrFigure, currentFigureColumn, isOneStep, dir, -1, -1);

            return deleteStep;
        }
        private bool CheckDirection(int currentFigureRow, int currentFigureColumn, bool isOneStep, int[] dir, int deltaI, int deltaJ)
        {
            bool eatStep = false;
            int j = currentFigureColumn + deltaJ;
            for (int i = currentFigureRow + deltaI; i >= 0 && i < 8; i += deltaI)
            {
                if ((currentPlayer == 1 && isOneStep && !isContinue) || (dir[0] == deltaI && dir[1] == deltaJ && !isOneStep))
                    break;
                if (IsInsideBorders(i, j))
                {
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i + deltaI, j + deltaJ))
                            eatStep = false;
                        else if (map[i + deltaI, j + deltaJ] != 0)
                            eatStep = false;
                        else
                            return eatStep;
                    }
                }
                j += deltaJ;
                if (isOneStep)
                    break;
            }
            return eatStep;
        }
        public bool IsInsideBorders(int ti,int tj)
        {
            if(ti>=MapSize || tj >= MapSize || ti<0 || tj < 0)
            {
                return false;
            }
            return true;
        }

        // Field status
        public void ActivateAllButtons()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    buttons[i, j].Enabled = true;
                }
            }
        }
        public void DeactivateAllButtons()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    buttons[i, j].Enabled = false;
                }
            }
        }

        // Other actions
        public void DeleteFallenChekers(Button endButton, Button startButton)
        {
            int count = Math.Abs(endButton.Location.Y / CageSize - startButton.Location.Y / CageSize);
            int startIndexX = endButton.Location.Y / CageSize - startButton.Location.Y / CageSize;
            int startIndexY = endButton.Location.X / CageSize - startButton.Location.X / CageSize;
            startIndexX = startIndexX < 0 ? -1 : 1;
            startIndexY = startIndexY < 0 ? -1 : 1;
            int currCount = 0;
            int i = startButton.Location.Y / CageSize + startIndexX;
            int j = startButton.Location.X / CageSize + startIndexY;
            while (currCount < count - 1)
            {
                map[i, j] = 0;
                buttons[i, j].Image = null;
                buttons[i, j].Text = "";
                i += startIndexX;
                j += startIndexY;
                currCount++;
            }
            UpdateCheckersCountLabels();

        }
        public bool DeterminePath(int ti, int tj)
        {

            if (map[ti, tj] == 0 && !isContinue)
            {
                buttons[ti, tj].BackColor = Color.Yellow;
                buttons[ti, tj].Enabled = true;
                simpleSteps.Add(buttons[ti, tj]);
            }
            else
            {

                if (map[ti, tj] != currentPlayer)
                {
                    if (pressedButton.Text == "👑")
                        ShowProceduralDead(ti, tj, false);
                    else ShowProceduralDead(ti, tj);
                }

                return false;
            }
            return true;
        }
        public void DamkaModActivated(Button button)
        {
            if (map[button.Location.Y / CageSize, button.Location.X / CageSize] == 1 && button.Location.Y / CageSize == MapSize - 1)
            {
                button.Text = "👑";

            }
            if (map[button.Location.Y / CageSize, button.Location.X / CageSize] == 2 && button.Location.Y / CageSize == 0)
            {
                button.Text = "👑";
            }
        }
    }
}