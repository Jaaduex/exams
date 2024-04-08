#pract1
# pip install wikipedia
#pip install wordcloud
from wordcloud import WordCloud, STOPWORDS 
import matplotlib.pyplot as plt 
import wikipedia as wp
result = wp.page("Computer Science") 
final_result = result.content 
print(final_result) 
def plot_wordcloud(wc): 
    plt.axis("off") 
    plt.figure(figsize=(10, 10)) 
    plt.imshow(wc) 
    plt.show() 
# Generate word cloud
wc = WordCloud(width=500, height=500, background_color="cyan", random_state=10, stopwords=STOPWORDS).generate(final_result) 
wc.to_file("ds.png") 
plot_wordcloud(wc)
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract2A
import pandas as pd
from bs4 import BeautifulSoup
from urllib.request import urlopen
url = "https://en.wikipedia.org/wiki/List_of_Asian_countries_by_area"
page = urlopen(url)
html_page = page.read().decode("utf-8")
soup = BeautifulSoup(html_page, "html.parser")
table = soup.find("table")
print(table)
SrNo = []
Country = []
Area = []
rows = table.find("tbody").find_all("tr")
for row in rows:
    cells = row.find_all("td")
    if cells:
        SrNo.append(cells[0].get_text().strip("\n"))
        Country.append(cells[1].get_text().strip("\xa0").strip("\n").strip("\[2]*"))
        Area.append(cells[3].get_text().strip("\n").replace(",", ""))
countries_df = pd.DataFrame()
countries_df["ID"] = SrNo
countries_df["Country Name"] = Country
countries_df["Area"] = Area
print(countries_df.head(10))
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract2B
import pandas as pd
import urllib.request
import json
url = "https://jsonplaceholder.typicode.com/users"
response = urllib.request.urlopen(url)
data = json.loads(response.read())
print(data)
id = []
username = []
email = []
for item in data:
    if "username" in item.keys():
        username.append(item["username"])
    else:
        username.append("NA")
        
    if "id" in item.keys():
        id.append(item["id"])
    else:
        id.append("NA")

    if "email" in item.keys():
        email.append(item["email"])
    else:
        email.append("NA")

print(id)
print(username)
print(email)
accounts = pd.DataFrame()
accounts['User_ID'] = id
accounts['Username'] = username
accounts['Email'] = email
accounts.head(10)
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract3 in R
df = read.csv("mtcars.csv")
View(df)
str(df) # Gives structure of the dataframe
# Get Dimension of dataframe
dim(df)
names(df) # gives column names as vector
row.names(df) = df$model # assign variable name as row name
df = df[,-1]
library("dplyr")
# SELECT FUNCTION
df1 = df %>% select(mpg:hp)
View(df1)
df1 = df %>% select(c(mpg,hp, wt))
View(df1)
## FILTER FUNCTION
df1 = df %>% filter(gear==4 | mpg>20) %>%
  select(c(mpg,hp,wt,gear))
View(df1)
## ARRANGE FUNCTION
df1 = df %>% arrange(cyl, desc(mpg))
View(df1)
# RENAME FUNCTION
df1 = df %>% rename(MilesPerGallon = mpg, Displacement = disp)
View(df1)
# MUTATE FUNCTION
row.names(df) = df$model
df1 = df %>% mutate(Power = hp * wt)
View(df1)
# GROUP BY AND SUMMARISE FUNCTION
df$cyl = as.factor(df$cyl)
df1 = df %>% group_by(df$cyl) %>%
  summarise(n=n(), mean_mpg = mean(mpg))
View(df1)
# group df by year and summarise meanofmpg, dispacemnet,weight
df$gear = as.factor(df$gear)
df1 = df %>% group_by(df$gear) %>%
  summarise(n=n(), mean_mpg = mean(mpg), mean_disp = mean(disp), mean_wt = mean(wt))
View(df1)
# Data Visualization
# Histogram
hist(df$mpg) # Gives histogram graph for the specified column
hist(df$mpg, main="Histogram of MPG(mtcars)",
     col="lightgreen", border="darkorange", xlab="Miles per Gallon") # Main is for title, col for colour, border is for border color and xlab is used to set label for x-axis
# Barplot
df$cyl = as.factor(df$cyl)
table(df$cyl)
barplot(table(df$cyl))
# BoxPlot
summary(df$mpg)
boxplot(df$mpg)
# Scatterplot
plot(df$mpg ~ df$disp) # df$mpg ~ df$disp means => The effect of Displacement on MPG
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract4
#!/usr/bin/env python
# coding: utf-8
# In[3]:
import pandas as pd 
import os 
os.getcwd() 
titanic=pd.read_csv(r"train.csv")
# In[4]:
titanic.head()
# In[5]:
titanic.info()
# In[6]:
titanic.describe()
# In[7]:
titanic.isnull().sum()
# In[8]:
titanic_cleaned = titanic.drop(['PassengerId','Name','Ticket','Fare','Cabin'],axis=1) 
titanic_cleaned.info() 
# In[9]:
import seaborn as sns
import matplotlib.pyplot as plt
get_ipython().run_line_magic('matplotlib', 'inline')
sns.catplot(x="Sex", hue="Survived", kind="count", data=titanic_cleaned)  # hue == legend count is plotted on y axis
# In[10]:
titanic_cleaned.groupby(['Sex','Survived'])['Survived'].count()
# In[11]:
group1 = titanic_cleaned.groupby(['Sex','Survived'])
gender_survived = group1.size().unstack()
gender_survived
sns.heatmap(gender_survived, annot=True, fmt="d")
# In[12]:
group2 = titanic_cleaned.groupby(["Pclass","Survived"]) 
pclass_survived = group2.size().unstack() 
pclass_survived 
sns.heatmap(pclass_survived, annot=True, fmt="d") #d
# In[13]:
#violin plot -- distribution of data isintegerannotation
sns.violinplot(x="Sex",y="Age",hue="Survived",data=titanic_cleaned,split=True) #split
# In[14]:
print("Oldest person on board: ",titanic_cleaned["Age"].max())
# In[15]:
print("Youngest person on board: ",titanic_cleaned["Age"].min()) 
# In[16]:
print("Average age of people on board: ",titanic_cleaned["Age"].mean())
# In[17]:
titanic_cleaned.isnull().sum()
def impute(cols):
    Age = cols[0]
    Pclass = cols[1]
    if pd.isnull(Age):
        if Pclass == 1:
            return 38
        elif Pclass == 2:
            return 29
        else:
            return 24
    else:
        return Age
titanic_cleaned["Age"] = titanic_cleaned[["Age", "Pclass"]].apply(impute, axis=1)
titanic_cleaned.isnull().sum()
# In[18]:
titanic_cleaned.corr(method='pearson') 
# In[19]:
sns.heatmap(titanic_cleaned.corr(method="pearson"),annot=True,vmax=1)
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract5
#!/usr/bin/env python
# coding: utf-8
# 1)Write a python program to build a regression model that could predict the salary of an  employee from the given experience and visualize univariate linear regression on it.
# In[1]:
import numpy as np
from sklearn import datasets
x, y, coef = datasets.make_regression(n_samples=100, n_features=1, n_informative=1, noise=10, coef=True, random_state=0)
# Scale feature x for exp from 0 to 20
x = np.interp(x, (x.min(), x.max()), (0, 20))
print(len(x))
print(x)
# In[3]:
import numpy as np
# Assuming 'y' is your salary data
# Scale target y (salary) to the range 20000 to 150000
y = np.interp(y, (y.min(), y.max()), (20000, 150000))
# Check the length of y
print(len(y))
print(y)
# In[4]:
import matplotlib.pyplot as plt 
plt.plot(x, y, '.', label='training data') 
plt.xlabel("Years of Experience") 
plt.ylabel("Salary") 
plt.title("Experience VS Salary")
# In[7]:
from sklearn.linear_model import LinearRegression 
import matplotlib.pyplot as plt
reg_model = LinearRegression() 
reg_model.fit(x, y) 
y_predicted = reg_model.predict(x)
plt.plot(x, y, '.', label='training data') 
plt.xlabel("Years of Experience") 
plt.ylabel("Salary") 
plt.title("Experience VS Salary")
plt.plot(x,y_predicted,color="black")
# In[9]:
import numpy as np
import pandas as pd
# Assuming x and y are already defined
data = {'Experience': np.round(x.flatten()), "Salary": np.round(y)}
df = pd.DataFrame(data)
df.head(10)
# In[10]:
x1=[[6.0]] 
y1=reg_model.predict(x1) 
print(y1) 
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract5B
# 2)Write a python program to simulate linear model Y=10+7*x+e for random 100 samples and visualize 
univariate linear regression on it. 
from sklearn.linear_model import LinearRegression
import matplotlib.pyplot as plt
import numpy as np
reg_model = LinearRegression()
x = np.random.rand(100,1)
beeta0 = 10
beeta1 = 7
error = np.random.rand(100,1)
y = beeta0 + beeta1 * x + error
reg_model.fit(x, y)
y_predicted = reg_model.predict(x)
plt.scatter(x, y, s=10)
plt.xlabel("X")
plt.ylabel("Y")
plt.plot(x, y_predicted, color="black")
plt.show()
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract6
# In[1]:
import pandas as pd
import matplotlib.pyplot as plt
import sklearn
boston = pd.read_csv(r"C:\Users\Dinesh\OneDrive\Desktop\Practise\DS pracrical\Boston.csv")
boston.head()
# In[2]:
boston.info()
# In[3]:
boston=boston.drop(columns="Unnamed: 0") 
boston.head()
# In[4]:
##All the rows from 0 to 12 will be retrive 
boston_x=pd.DataFrame(boston.iloc[:,:13]) 
# In[5]:
##only the last column will be removed 
boston_y=pd.DataFrame(boston.iloc[:,-1])
# In[6]:
from sklearn.model_selection import train_test_split 
# In[7]:
X_train,X_test,Y_train,Y_test=train_test_split(boston_x,boston_y,test_size=0.3) 
# In[8]:
print("xtrain shape",X_train.shape)
print("ytrain shape",Y_train.shape) 
print("xtest shape",X_test.shape) 
print("ytest shape",Y_test.shape)
# In[10]:
from sklearn.linear_model import LinearRegression 
regression=LinearRegression() 
regression.fit(X_train,Y_train) 
Y_pred_linear=regression.predict(X_test) 
Y_pred_df=pd.DataFrame(Y_pred_linear,columns=["Predicted"]) 
Y_pred_df.head()
# In[13]:
plt.scatter(Y_test,Y_pred_linear,c="green") 
plt.xlabel("Actual Price(medv)") 
plt.ylabel("Predicted Price") 
plt.title("Actual vs predicted Price ") 
plt.show
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract7 in R
# Read the "train.csv" file and store it as a data frame called titanic
titanic <- read.csv("C:\\Users\\Dinesh\\OneDrive\\Desktop\\Practise\\DS pracrical\\train.csv")
# Open a new tab in RStudio to display the titanic data frame
View(titanic)
# Display the number of rows and columns in the titanic data frame
dim(titanic)
# Load the dplyr package for data manipulation
library(dplyr)
# Create a new data frame called clean_titanic by selecting all columns except
# "Cabin", "Ticket", "Fare", and "Name" from the titanic data frame
clean_titanic <- titanic %>%
  select(-c("Cabin", "Ticket", "Fare", "Name"))
# Display the number of rows and columns in the clean_titanic data frame
dim(clean_titanic)
# Open a new tab in RStudio to display the clean_titanic data frame
View(clean_titanic)
# Display the structure of the clean_titanic data frame
str(clean_titanic)
# Update the clean_titanic data frame by converting the Pclass and Survived columns to
# factors with labels "Upper", "Middle", and "Lower" for Pclass and "Not survived" and "Survived" for Survived
clean_titanic <- clean_titanic %>%
  mutate(Pclass = factor(Pclass, levels = c(1, 2, 3), labels = c("Upper", "Middle", "Lower")),
         Survived = factor(Survived, levels = c(0, 1), labels = c("Not survived", "Survived")))
# Open a new tab in RStudio to display the updated clean_titanic data frame
View(clean_titanic)
# Remove any rows with missing values (NAs) from the clean_titanic data frame
clean_titanic <- na.omit(clean_titanic)
# Display the number of rows and columns in the updated clean_titanic data frame
dim(clean_titanic)
# Create a vector of row indices for the training data by sampling 70% of the rows from the clean_titanic data frame
# and sorting them in ascending order
dt <- sort(sample(nrow(clean_titanic), nrow(clean_titanic) * 0.7))
# Create a new data frame called train_titanic by selecting the rows in the clean_titanic data frame with the row indices in dt
train_titanic <- clean_titanic[dt,]
# Create a new data frame called test_titanic by selecting the rows in the clean_titanic data frame that are not in train_titanic
test_titanic <- clean_titanic[-dt,]
# Display the number of rows and columns in the train_titanic data frame
dim(train_titanic)
# Display the number of rows and columns in the test_titanic data frame
dim(test_titanic)
# Load the rpart package for building decision trees
library(rpart)
# Load the rpart.plot package for plotting decision trees
library(rpart.plot)
# Create a decision tree model called titanic_model by fitting a tree to the Survived column of the train_titanic data frame
# using all other columns as predictors, with the method set to "class" for classification
titanic_model <- rpart(Survived ~ ., data = train_titanic, method = "class")
# Plot the titanic_model decision tree using the rpart.plot() function
rpart.plot(titanic_model, extra = 106)
# Create a vector called predict_unseen containing the predicted values
# for the Survived column of the test_titanic data frame using the titanic_model decision tree
# and setting the type to "class" to get the class predictions (i.e., "Not survived" or "Survived")
predict_unseen <- predict(titanic_model, test_titanic, type = "class")
# Display the predicted values in predict_unseen
predict_unseen
# Load the caret package for evaluating machine learning models
library(caret)
# Create a confusion matrix called con_mat by comparing the predicted values in predict_unseen to the actual values in
# the Survived column of the test_titanic data frame
con_mat <- confusionMatrix(test_titanic$Survived, predict_unseen)
# Display the confusion matrix in con_mat
con_mat
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#pract8
#!/usr/bin/env python
# coding: utf-8
# In[2]:
import numpy as np 
import pandas as pd 
from matplotlib import pyplot as plt 
from sklearn.datasets import load_breast_cancer 
from sklearn.metrics import confusion_matrix 
from sklearn.neighbors import KNeighborsClassifier 
from sklearn.model_selection import train_test_split 
import seaborn as sns 
sns.set() 
breast_cancer = load_breast_cancer()
x = pd.DataFrame(breast_cancer.data, columns=breast_cancer.feature_names)
x.head()
# In[3]:
x=x[["mean area","mean compactness"]] 
x.head
# In[4]:
x.info() 
# In[5]:
y=pd.Categorical.from_codes(breast_cancer.target,breast_cancer.target_names) 
print(y)
# In[6]:
y=pd.get_dummies(y,drop_first=True) 
print(y) 
# In[7]:
x_train,x_test,y_train,y_test=train_test_split(x,y,random_state=1) 
knn=KNeighborsClassifier(n_neighbors=5,metric="euclidean") 
knn.fit(x_train,y_train) 
sns.scatterplot(x="mean
 area",y="mean
 compactness",hue="benign",data=x_test.join(y_test,how="outer"))
# In[8]:
x_train, x_test, y_train, y_test = train_test_split(x, y, random_state=1) 
knn = KNeighborsClassifier(n_neighbors=5, metric="euclidean") 
knn.fit(x_train, y_train) 
sns.scatterplot(x="mean area", y="mean compactness", hue="benign", data=x_test.join(y_test, how="outer"))
# In[11]:
y_pred = knn.predict(x_test) 
plt.scatter(x_test["mean area"], x_test["mean compactness"], c=y_pred, cmap="coolwarm", alpha=0.7)
# In[12]:
cf=confusion_matrix(y_test,y_pred) 
print(cf)
# In[13]:
labels = ["True Negative", "False Positive", "False Negative", "True Positive"]
labels = np.asarray(labels).reshape(2, 2)
categories = ['Zero', 'One'] 
ax = plt.subplot() 
sns.heatmap(cf, annot=True, ax=ax) 
ax.set_xlabel("Predicted Values") 
ax.set_ylabel("True Values") 
ax.set_title("Confusion Matrix") 
ax.xaxis.set_ticklabels(["Malignant", "Benign"]) 
ax.yaxis.set_ticklabels(["Malignant", "Benign"])
# In[14]:
tp,fn,fp,tn=confusion_matrix(y_test,y_pred,labels=[1,0]).reshape(-1)
print("Values for  TP,FN,FP,TN:",tp,fn,fp,tn)
# In[15]:
Accuracy=(tp+tn)/(tp+tn+fp+fn) 
print(Accuracy) 
# In[16]:
from sklearn.metrics import f1_score 
f1_score(y_test,y_pred)
# In[17]:
from sklearn.metrics import roc_auc_score 
print(roc_auc_score(y_test,y_pred)) 
