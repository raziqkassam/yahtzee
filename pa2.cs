using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    class YahtzeeDice // ProgrammingAssignment2
    {	
		public int [ ] dice = new int [ 5 ]; // public dice array
        
        public void Roll ( )
        {
			Random rGen = new Random ( );
			
			for ( int i = 0; i < 5; i ++ )
			{
				// roll the dice random values from 1-6 if value=0
				// it is 0 when it is chosen to reroll or is just created
				
				if ( dice [ i ] == 0 ) dice [ i ] = rGen.Next( 1 , 7 );
			}
        }
			
        public override string ToString()
        {
				// create and format the displaying of the rolled dice
				string result = string.Format($"\t  {dice[0]}\t{dice[1]}\t{dice[2]}\t{dice[3]}\t{dice[4]}" );
				return result;
        }
        
        public void Unroll ( string faces ) // 'faces' is what was typed by user to be rolled again
        {
			if ( faces == "all" ) // set all dice to 0 to be rerolled if 'all' is typed
			{
				for ( int i = 0; i < 5; i ++ ) dice[ i ] = 0;
			}
			else
			{
				for  ( int j = 0; j < 5; j ++ )
				{
					for( int r = 0; r < faces.Length; r ++ )
					{
						// checks the 'r'th space and takes one letter ( number )
						// checks if it is equal to what was typed
						if ( dice[ j ] == int.Parse( faces.Substring( r , 1  ) ) )
						{
							// set dice to 0, so it can be rerolled
							dice [ j ] = 0;
							break;
						}
					}
				}
			}
		}
		
		public int Sum ( )
		{
			// sum up all the dice
			int sum = dice[ 0 ] + dice[ 1 ] + dice[ 2 ] + dice[ 3 ] + dice[ 4 ];
			
			return sum;
		}
		
		public int Sum ( int face )
		{
			int counter = 0;
			
			for ( int j = 0; j < 5; j ++ )
			{
				// count how many dice values are equal to the 'face' value
				if ( dice [ j ] == face ) counter ++;
			}
			// the sum is equal to the counter multiplied by the 'face' value
			int answer = (face * counter);
			
			return answer;
		}
		
		public bool IsRunOf ( int length )
		{
			int [ ] diceCopy = new int [ 5 ]; 
			
			// copying the values from the first array to a second array
			// in order for the copied array to be manipulated
			for ( int i = 0; i < 5; i ++ ) diceCopy [ i ] = dice [ i ];
			
			// copied dice array is sorted from low to high
			Array.Sort( diceCopy );
			
			// counter starts at 1 because its counting how many matches
			// matches + 1 equals the number of dice in the run
			int counter = 1;
			
				for ( int i = 0; i < 4; i ++ )
				{
					// if dice + 1 equal to the value of the next dice
					if ( diceCopy [ i ] + 1 == diceCopy [ i + 1 ] ) counter ++;
				}
			// check if the counter is equal or greater than length
			if ( counter >= length ) return true;
			else return false;
		}
		
		public bool IsSetOf ( int size )
		{
			
			for ( int i = 1; i < 7; i ++ )
			{
				int counter = 0;
				
				for ( int j = 0; j < 5; j ++ )
				{
					if ( dice [ j ] == i ) counter ++;
				}
				
				if ( counter >= size ) return true;
			}
			return false;
		}
		
		public bool IsFullHouse ( )
		{
			// count how many of each value you have
			// see if one is equal to 3 and one is equal to 2 (the counters)
			//		two possibilites ( 3 then 2 ) or ( 2 then 3 )
			// then a full house boolean is true
			
			for ( int i = 1; i < 7; i ++ )
			{
				int counter = 0;
				
				for ( int j = 0; j < 5; j ++ )
				{
					if ( dice [ j ] == i ) counter ++;
				
					if ( counter == 2 ) // possibility 2 then 3
					{
						for ( int k = i + 1; k < 8; k ++ )
						{
							int countThrees = 0;
							
							for ( int m = 0; m < 5; m ++ )
							{
								if ( dice [ m ] == k ) countThrees ++;
								
								if ( countThrees == 3 ) return true;
							}
						}
					}
						
					else if ( counter == 3 ) // possibility 3 then 2
					{
						for ( int k = i + 1; k < 8; k ++ )
						{
							int countTwos = 0;
							
							for ( int n = 0; n < 5; n ++ )
							{
								if ( dice [ n ] == k ) countTwos ++;
								
								if ( countTwos == 2 ) return true;
							}
						}
					}
				} 
			} 	 
			
			return false;
		} 	      
    }
}
