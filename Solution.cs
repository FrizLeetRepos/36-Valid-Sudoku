public class Solution {
    public bool IsValidSudoku(char[][] board) {
        for (int row = 0; row < board.Length; row++) {
            for (int col = 0; col < board[row].Length; col++) {
                if (board[row][col] == '.')
                    continue;

                if (!CheckRow(row, col, board) ||
                    !CheckCol(row, col, board) ||
                    !CheckLocalBox(row, col, board)) {
                    return false;
                }
            }
        }
        return true;
    }

    private bool CheckRow(int row, int col, char[][] board) {
        for (int j = 0; j < board[row].Length; j++) {
            if (j == col)
                continue;
            if (board[row][j] == board[row][col])
                return false;
        }
        return true;
    }
    private bool CheckCol(int row, int col, char[][] board) {
        for (int i = 0; i < board.Length; i++) {
            if (i == row)
                continue;
            if (board[i][col] == board[row][col])
                return false;
        }
        return true;
    }
    private bool CheckLocalBox(int row, int col, char[][] board) {
        int boxRow = row / 3;
        int boxCol = col / 3;

        int boxNum = (boxRow * 3) + boxCol;
        for (int i = boxRow * 3; i < (boxRow * 3) + 3; i++) {
            for (int j = boxCol * 3; j < (boxCol * 3) + 3; j++) {
                if (i == row && j == col)
                    continue;
                if (board[i][j] == board[row][col])
                    return false;
            }
        }
        return true;
    }
}