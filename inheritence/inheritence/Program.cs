// See https://aka.ms/new-console-template for more information
using inheritence;

//multilevel inheritence
puppy p = new puppy();
p.bark();
p.weep();

//hierarical inheritence

cat c= new cat();
c.eat();
c.shouts();

//multiple inheritence

Iswimmable i = new Duck();
i.swim();
Iflyable f=new Crane();
f.fly();