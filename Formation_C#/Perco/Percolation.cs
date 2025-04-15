using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        // Reponses aux questions
        // 3.b quelle est la performance de cette méthode dans le pire cas ?
        // Dans la pire situation, il faudrat remplir une case de la 1ere ligne + l'ensemble des cases du tableau pour les ligne suivante.
        // Par exemple pour un tableau de 6 x 6, cela revient à remplir 5 x 6 + 1 cases, soit 31 cases sur 36.
        // 3.c xpliquer, intuitivement, pour quelles raisons ce cas a-t-il peu de chances de se produire ?
        // Pour qu'un tel cas se produise, il faudrait qu'aucune case de la ligne de dessus ne soit ouverte, alors même que l'ensemble des autres cases du
        // tableau se soient ouvertes, en prenant une ouverture aléatoire, cela est très peu probable. 

        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

      //  List<KeyValuePair<int, int>> neigbors = new List<KeyValuePair<int, int>>();

        public Percolation(int size)
        {           
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        
        public bool IsOpen(int i, int j)
        {
            if (_open[i, j] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsFull(int i, int j)
        {
            if (_full[i, j] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Percolate()
        {
            for (int i = 0; i < _size; i++)
            {
                
                if (_full[_size - 1, i] == true)
                {
                    return true;

                }
                else
                {
                    return false;
                }
                            
            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
          List<KeyValuePair<int, int>> neigbors = new List<KeyValuePair<int, int>>();
           if (j != 0)
            {
               neigbors.Add(new KeyValuePair<int, int>(i, j-1));
                
            }
           if (i != 0)
            {
               neigbors.Add(new KeyValuePair<int, int>(i-1, j));
            }
           if (j != _size)
            {
                neigbors.Add(new KeyValuePair<int, int>(i, j+1));
            }
           if (i !=  _size)
            {
                neigbors.Add(new KeyValuePair<int, int>(i + 1, j));
            }
            
            return neigbors;
        }

        public void Open(int i, int j)
        {
        // on ouvre la case

            _open[i,j] = true;

        // on vérifie si la case est au sommet de la grille, dans ce cas, la case ouverte se remplie

            if (j == 0)
            {
                _full[i, j] = true;
            }
        // sinon, on vérifie si la case du dessus est full, si oui, on remplie, sinon, on laisse vide
            else
            {
                List<KeyValuePair<int, int>> neigbors = CloseNeighbors(i, j);
                for (int i2 = 0; i2 < neigbors.Count; i2++)
                {
                    if (IsFull(neigbors[i2].Key, neigbors[i2].Value))
                    {
                        _full[i, j] = true;
                    }
                    else
                    {
                        _full[i, j] = false;
                    }
                }
            }
            // il faut maintenant remplir les autres cases, en vérifiant si elles sont ouvertes ET vides (dans le cas ou la cas ouverte se remplie)

            if (_full[i, j] == true)
            {
                List<KeyValuePair<int, int>> neigbors = CloseNeighbors(i, j);
                for (int i2 = 0; i2 < neigbors.Count; i2++)
                {
                    if (IsOpen(neigbors[i2].Key, neigbors[i2].Value))
                    {
                        if (IsFull(neigbors[i2].Key, neigbors[i2].Value))

                        {
                        }

                        else
                        {
                            _full[neigbors[i2].Key, neigbors[i2].Value] = true;
                            Open(neigbors[i2].Key, neigbors[i2].Value);
                        }

                    }
                    else
                    {
                        _full[neigbors[i2].Key, neigbors[i2].Value] = false;
                    }


                }
            } 
        }
    }
}
