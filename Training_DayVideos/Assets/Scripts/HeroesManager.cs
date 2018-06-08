using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroesManager : MonoBehaviour
{
    public List<Hero> heroes = new List<Hero>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foreach (Hero hero in heroes)
            {
                if (hero.direction == Hero.HeroDirection.UP)
                    hero.ChangeDirection(Hero.HeroDirection.STAY);
                else if (hero.direction == Hero.HeroDirection.STAY)
                {
                    hero.ChangeDirection(Hero.HeroDirection.DOWN);
                }
                else if (hero.direction == Hero.HeroDirection.DOWN)
                {
                    hero.ChangeDirection(Hero.HeroDirection.STAY);
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach (Hero hero in heroes)
            {
                if (hero.direction == Hero.HeroDirection.DOWN)
                    hero.ChangeDirection(Hero.HeroDirection.STAY);
                else if (hero.direction == Hero.HeroDirection.STAY)
                {
                    hero.ChangeDirection(Hero.HeroDirection.UP);
                }
                else if (hero.direction == Hero.HeroDirection.UP)
                {
                    hero.ChangeDirection(Hero.HeroDirection.STAY);
                }
            }
        }
    }
}
