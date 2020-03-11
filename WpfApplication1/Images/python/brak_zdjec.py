from pathlib import Path

import datetime
import os
import datetime
import shutil
print("hello")
print('2+2')
zmienna=1
inna=2
ala=zmienna+inna
print(ala)
print(zmienna.bit_length())
slowo="kot"
print(slowo.isupper())
print(slowo.upper())
print(slowo.isupper())
print(slowo.lower())
print(slowo[2])
print(slowo.find("o"))
"""""
txt = Path('\\plkwim0taxlog57\\c$\\Users\\grabowss\\Desktop\\IP_MKwiag.txt').read_text()
print(txt.find('17'))
k = txt.find("17")
print(k)
print(txt[k+3:k+11])
fileName=datetime.datetime.now()
def create_file():
    with open(fileName.strftime("%d %B %Y %H")+"ala"+".txt", "w") as file:
        file.write("dupa")

create_file()


def modification_date(filename):
    t = os.path.getmtime(filename)
    return datetime.datetime.fromtimestamp(t)

d = modification_date('\\plkwim0taxlog57\\c$\\Users\\grabowss\\Desktop\\aaa.txt')

print (d)
e = modification_date('\\plkwim0taxlog57\\c$\\Users\\grabowss\\Desktop\\aa.txt')

print (e)
if d > e:
    print("porównanie ok")
    shutil.copyfile('\\plkwim0taxlog57\\c$\\Users\\grabowss\\Desktop\\IP_MKwiag.txt','\\plkwim0taxlog57\\c$\\Users\\grabowss\\Desktop\\A\\IP_MKwiag.txt')
    k=1
while e > d:
    print("ok")
    txt = Path('\\plkwim0taxlog57\\c$\\Users\\grabowss\\Desktop\\aa.txt').read_text()
    file = open('\\plkwim0taxlog57\\c$\\Users\\grabowss\\Desktop\\aa.txt','w')
    file.write(txt+'\r\n')
    k=k+1
    file.write(str(k))
    file.write(fileName.strftime(" %H %M %S"))
    file.close()
    fileName = datetime.datetime.now()

    print('dupa')



    print("jest ok")
"""""
bufor=0
#\\\\plkwim0taxlog57\
txt = Path('\\plkwim0taxlog57\\c$\opis\\fix.txt').read_text()
dlugoscTekstu=1
while dlugoscTekstu <= (len(txt)-10):
    k = txt.find(";",dlugoscTekstu)
    #print(txt[k-2:k])
    dlugoscTekstu=k+1
   # print ("edfefe",txt[k-2:k])
    if txt[k-2:k].isdigit():
         if int(txt[k-2:k]) > int(bufor):
            bufor=txt[k-2:k]
print("Najwieksza znaleziona fikstura to ",bufor)

zdj=''
i=1
while i< int(bufor):
    #\\\\plkwim0taxlog57\\     zamiast $ to :
    fname = "\\plkwim0taxlog57\\c$\\opis\\zdjecia\\"+ str(i)+'.jpg'

    if not os.path.isfile(fname):
        zdj = zdj + " ,"+str(i)
       # print("Brak zdjecia : ",i)
       # print(fname)
    i=i+1

print("Brak zdjęć :" , zdj[2:])
#\\\\plkwim0taxlog57\\
fileName = "\\plkwim0taxlog57\\c$\\opis\\zdjecia\\brak_zdjęć"

def create_file():
    with open(fileName+".txt", "w") as file:
        file.write("Najnowsza znaleziona fikstura to " +bufor +"\r\n" + "Brak zdjec : "+ zdj[2:])

create_file()
