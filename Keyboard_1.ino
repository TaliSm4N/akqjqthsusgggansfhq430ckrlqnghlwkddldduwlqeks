const int BUTTON_1 = 2;
const int BUTTON_2 = 6;
const int BUTTON_3 = 10;

boolean running_1 = false;
boolean running_2 = false;
boolean running_3 = false;
int check=0;

void setup()
{
  pinMode(BUTTON_1, INPUT);
  pinMode(BUTTON_2, INPUT);
  pinMode(BUTTON_3, INPUT);
  Keyboard.begin();
}

void loop()
{
  
  if(check==0)
  {
    if (digitalRead(BUTTON_1) == HIGH)
    {
      Keyboard.press('j');
      Keyboard.release('j');
      check=1;
    }
  }
    else if(digitalRead(BUTTON_1) == LOW)
    {
      Keyboard.press('k');
      Keyboard.release('k');
      check=0;
    }
  else if (running_2)
  {
    Keyboard.print("k");
  }
  else if (running_3)
  {
    Keyboard.print("l");
  }
}


