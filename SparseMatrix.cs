using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class SparseMatrix
    {
        private Dictionary<(int, int), int> elements; // Store non-zero elements as (row, column) => value

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public SparseMatrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            elements = new Dictionary<(int, int), int>();
        }

        public void SetValue(int row, int column, int value)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException("Invalid row or column index.");

            var key = (row, column);
            if (value != 0)
                elements[key] = value;
            else if (elements.ContainsKey(key))
                elements.Remove(key);
        }

        public int GetValue(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException("Invalid row or column index.");

            var key = (row, column);
            return elements.ContainsKey(key) ? elements[key] : 0;
        }

        public SparseMatrix Transpose()
        {
            var result = new SparseMatrix(Columns, Rows);

            foreach (var entry in elements)
            {
                var (row, col) = entry.Key;
                result.SetValue(col, row, entry.Value);
            }

            return result;
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(GetValue(i, j) + "\t");
                }
                Console.WriteLine();
            }
        }

        public static SparseMatrix operator +(SparseMatrix matrix1, SparseMatrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new InvalidOperationException("Matrices must have the same dimensions for addition.");

            var result = new SparseMatrix(matrix1.Rows, matrix1.Columns);

            foreach (var entry in matrix1.elements)
            {
                var (row, col) = entry.Key;
                result.SetValue(row, col, entry.Value + matrix2.GetValue(row, col));
            }

            foreach (var entry in matrix2.elements)
            {
                var (row, col) = entry.Key;
                if (!result.elements.ContainsKey((row, col)))
                    result.SetValue(row, col, entry.Value);
            }

            return result;
        }

        public static SparseMatrix operator *(SparseMatrix matrix1, SparseMatrix matrix2)
        {
            if (matrix1.Columns != matrix2.Rows)
                throw new InvalidOperationException("Number of columns in the first matrix must be equal to the number of rows in the second matrix.");

            var result = new SparseMatrix(matrix1.Rows, matrix2.Columns);

            foreach (var entry1 in matrix1.elements)
            {
                var (row1, col1) = entry1.Key;
                var value1 = entry1.Value;

                foreach (var entry2 in matrix2.elements)
                {
                    var (row2, col2) = entry2.Key;
                    var value2 = entry2.Value;

                    if (col1 == row2)
                        result.SetValue(row1, col2, result.GetValue(row1, col2) + value1 * value2);
                }
            }

            return result;
        }

        public int[] MultiplyByVector(int[] vector)
        {
            if (vector.Length != Columns)
                throw new InvalidOperationException("Vector length must be equal to the number of columns in the matrix.");

            int[] result = new int[Rows];

            foreach (var entry in elements)
            {
                var (row, col) = entry.Key;
                result[row] += entry.Value * vector[col];
            }

            return result;
        }
    }

    public class SparseList
    {
        private Dictionary<int, int> elements; // Store non-zero elements as index => value

        public int Count { get; private set; }

        public SparseList()
        {
            elements = new Dictionary<int, int>();
            Count = 0;
        }

        public void Add(int index, int value)
        {
            elements[index] = value;
            Count++;
        }

        public int GetValue(int index)
        {
            return elements.ContainsKey(index) ? elements[index] : 0;
        }

        public void SetValue(int index, int value)
        {
            if (value != 0)
                elements[index] = value;
            else if (elements.ContainsKey(index))
            {
                elements.Remove(index);
                Count--;
            }
        }

        public int FindByValue(int value)
        {
            foreach (var entry in elements)
            {
                if (entry.Value == value)
                    return entry.Key;
            }
            return -1; // Value not found
        }

        public int FindByCondition(Func<int, bool> condition)
        {
            foreach (var entry in elements)
            {
                if (condition(entry.Value))
                    return entry.Key;
            }
            return -1; // Element not found satisfying the condition
        }
    }
}
