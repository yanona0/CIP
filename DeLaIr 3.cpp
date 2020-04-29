#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <cmath>

std::vector<int> DeLaIr_first_square(int size)
{
	std::vector<int> square;
	int count;
	int center = size / 2 + 1;
	for (int row = 0; row < size; ++row)
	{
		count = 1;
		for (int col = 0; col < size; ++col)
		{
			if (col + row == size - 1)
			{
				square.push_back(center);
				count = 1;
			}

			else
			{
				if (row + col + count >= center && count == 1)
					count = 2;
				if (row + col + count > size && row + col + count - size <= center)
					count = 1;
				row + col + count > size ? square.push_back(row + col + count - size) : square.push_back(row + col + count);
			}

		}
	}
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			std::cout << square[size * i + j] << ", ";
		}
		std::cout << std::endl;
	}
	
	return square;
}

std::vector<int> DeLaIr_second_square(int size)
{
	std::vector<int> square;
	int count_t;
	int count_b;
	int center = size * (size / 2);
	for (int row = 0; row < size; ++row)
	{
		count_t = 1;
		count_b = 0;
		for (int col = 0; col < size; ++col)
		{
			count_b = 0;
			if (col == row)
			{
				square.push_back(center);
				count_t = 1;
			}
			else
			{
				if (((col - (row + count_t)) * size) >= center && count_t == 1)
					count_t = 0;
				if ((size - row + (col + count_b)) * size <= center && count_b == 0)
					count_b = 1;
				row > col ? square.push_back((size - row + (col - count_b)) * size) : square.push_back(((col - (row + count_t)) * size));
			}

		}
	}
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			std::cout << square[size * i + j] << ", ";
		}
		std::cout << std::endl;
	}
	std::cout << std::endl;
	return square;
}

std::string DeLaIr_imaginary_square(std::vector<int> square_1, std::vector<int> square_2)
{
	std::string im_square;
	for (int i = 0; i < square_1.size(); ++i)
	{
		im_square.push_back(square_1[i] + square_2[i]);
		if (i % (int)pow(square_1.size(), 0.5) == 0)
			std::cout << std::endl;
		std::cout << square_1[i] + square_2[i] << "  ";
		
	}
	return im_square;
}
void DeLaIr_encrypt(std::string text)
{

	int size_sq = pow(text.length(), 0.5) + 1;
	//only odd size
	if (size_sq % 2 == 0)
		++size_sq;
	//first square
	std::string cipher;
	cipher = DeLaIr_imaginary_square(DeLaIr_first_square(size_sq), DeLaIr_second_square(size_sq));


		
	for(int position = 1; position <= text.length(); ++position)
	{
		for (auto& el : cipher)
		{
			if (el == position)
				el = text[position - 1];
		}
	}

	for (int position = text.length(); position <= cipher.size(); ++position)
	{
		for (auto& el : cipher)
		{
			if (el == position)
				//el = rand() % 10 + 34;
				el = '_';//9th symbol if 8
		}
	}
	std::cout<<cipher<<std::endl;
}

std::string DeLaIr_decrypt(std::string cipher, int size)
{
	std::string text;
	int size_sq = pow(size, 0.5) + 1;
	//only odd size
	if (size_sq % 2 == 0)
		++size_sq;
	std::string square = DeLaIr_imaginary_square(DeLaIr_first_square(size_sq), DeLaIr_second_square(size_sq));
	for (int position = 1; position <= size; ++position)
	{
		for (int i = 0; i <= cipher.length(); ++i)
		{
			if (square[i] == position)
				text.push_back(cipher[i]);
		}
	}
	return text;

}

int main()
{
	std::cout << "Program: De la Ir Cipher" << std::endl;
	std::cout << "1. encrypt" << std::endl;
	std::cout << "2. decrypt" << std::endl;
	std::cout << "Your choice...";
	int choice;
	std::cin >> choice;
	std::cout << std::endl;
	std::string text;
	switch (choice)
	{
	case 1:
		std::cout << "Your text: ";
		std::cin >> text;
		DeLaIr_encrypt(text);
		break;
	case 2:
		std::cout << "Your text: ";
		std::cin >> text;
		std::cout << "input size: ";
		int size;
		std::cin >> size;
		std::cout << DeLaIr_decrypt(text,size) << std::endl;
		break;
	default:
		std::cout << "ERROR" << std::endl;
		break;
	}
	
}
