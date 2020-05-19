﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using WPF_Miner.Controls;

namespace WPF_Miner.Data
{
    public static class Calculations
    {
        /// <summary>
        /// Randomly generate mine field
        /// </summary>
        /// <param name="_x">Dimension X of the mine field</param>
        /// <param name="_y">Dimension Y of the mine field</param>
        /// <param name="_bombsAmount">Amount of the bombs</param>
        public static bool[,] GenerateMineField(int _x, int _y, int _bombsAmount )
        {
            Random random = new Random();
            bool[,] bombsMap = new bool[_x, _y];
            for (int i = 0; i < _bombsAmount; i++)
            {
                do
                {
                    int randomX = random.Next(0, _x);
                    int randomY = random.Next(0, _y);

                    if (!bombsMap[randomX, randomY])
                    {
                        bombsMap[randomX, randomY] = true;
                        break;
                    }
                } while (true);
            }
            return bombsMap;
        }

        public static void SetCellType(bool[,] _bombsMap, Cell _cell)
        {
            //Amount bombs around cell
            int bombAround = GetBombsAround(_cell.X, _cell.Y, (x, y) =>
            {
                if (x < 0 || y < 0 || x >= _bombsMap.GetLength(0) || y >= _bombsMap.GetLength(1)) return false;
                return _bombsMap[x, y] == true;
            });
            //Set Type to the cell
            switch (bombAround)
            {
                case 0:
                    _cell.Type = CellType.Empty;
                    break;
                case 1: 
                    _cell.Type = CellType.Near1;
                    break;
                case 2: 
                    _cell.Type = CellType.Near2;
                    break;
                case 3: 
                    _cell.Type = CellType.Near3;
                    break;
                case 4:
                    _cell.Type = CellType.Near4;
                    break;
                case 5:
                    _cell.Type = CellType.Near5;
                    break;
                case 6:
                    _cell.Type = CellType.Near6;
                    break;
                case 7:
                    _cell.Type = CellType.Near7;
                    break;
                case 8:
                    _cell.Type = CellType.Near8;
                    break;
                default:
                    break;
            }
            //in case of cell is bomb
            if (_bombsMap[_cell.X, _cell.Y] == true)
            {
                _cell.Type = CellType.Bomb;
            }
        }

        private static int GetBombsAround(int x, int y, Func<int, int, bool> check)
        {
            var bombs = new[]
            {                
                check(x - 1, y + 1),
                check(x, y + 1),
                check(x + 1, y + 1),
                check(x - 1, y),
                check(x, y),
                check(x + 1, y),
                check(x - 1, y - 1),
                check(x, y - 1),
                check(x + 1, y - 1),
            };
            return bombs.Where(isBomb => isBomb).Count();
        }

        public static void MakeAllEmptyCellAroundOpened(Cell[,] _allCells, Cell _cell)
        {
            int bombAround = GetBombsAround(_cell.X, _cell.Y, (x, y) =>
            {
                if (x < 0 || y < 0 || x >= _allCells.GetLength(0) || y >= _allCells.GetLength(1)) return false;
                return _allCells[x, y].Type == CellType.Bomb;               
            });
            _cell.Status = CellStatus.Opened;
            if (bombAround == 0)
            {                
                //open all cells around
                int nextX = _cell.X - 1;
                int nextY = _cell.Y + 1;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
                nextX = _cell.X;
                nextY = _cell.Y + 1;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
                nextX = _cell.X + 1;
                nextY = _cell.Y + 1;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
                nextX = _cell.X -1;
                nextY = _cell.Y;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
                nextX = _cell.X + 1;
                nextY = _cell.Y;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
                nextX = _cell.X - 1;
                nextY = _cell.Y - 1;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
                nextX = _cell.X;
                nextY = _cell.Y - 1;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
                nextX = _cell.X + 1;
                nextY = _cell.Y - 1;
                if (CheckCoordinateCorrect(nextX, nextY, _allCells)) MakeAllEmptyCellAroundOpened(_allCells, _allCells[nextX, nextY]);
            }
        }

        private static bool CheckCoordinateCorrect(int x, int y, Cell[,] _allCells)
        {
            if (x >= 0 && y >= 0 && x < _allCells.GetLength(0) && y < _allCells.GetLength(1) && 
                _allCells[x,y].Status != CellStatus.Opened && 
                _allCells[x,y].Status != CellStatus.Flagged)            
                return true;
            return false;
        }
    }
}
