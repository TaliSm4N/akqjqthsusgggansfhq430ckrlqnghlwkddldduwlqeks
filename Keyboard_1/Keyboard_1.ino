const int BUTTON_1 = 2;
const int BUTTON_2 = 6;
const int BUTTON_3 = 10;

boolean running_1 = false;
boolean running_2 = false;
boolean running_3 = false;
int check_1=0;
int check_2=0;
int check_3=0;

void setup()
{
  pinMode(BUTTON_1, INPUT);
  pinMode(BUTTON_2, INPUT);
  pinMode(BUTTON_3, INPUT);
  Keyboard.begin();
}

void loop()
{
  
  if(check_1==0)
  {
    if (digitalRead(BUTTON_1) == HIGH)
    {
      Keyboard.press('j');
      Keyboard.release('j');
      check_1=1;
    }
  }
    else if(digitalRead(BUTTON_1) == LOW)
    {
      Keyboard.press('k');
      Keyboard.release('k');
      check_1=0;
      delay(10);
    }
  
  if(check_2==0)
  {
    if (digitalRead(BUTTON_2) == HIGH)
    {
      Keyboard.press('o');
      Keyboard.release('o');
      check_2=1;
    }
  }
    else if(digitalRead(BUTTON_2) == LOW)
    {
      Keyboard.press('p');
      Keyboard.release('p');
      check_2=0;
      delay(10);
    }
    
  if(check_3==0)
  {
    if (digitalRead(BUTTON_3) == HIGH)
    {
      Keyboard.press('a');
      Keyboard.release('a');
      check_3=1;
    }
  }
    else if(digitalRead(BUTTON_3) == LOW)
    {
      Keyboard.press('b');
      Keyboard.release('b');
      check_3=0;
      delay(10);
    }
}


