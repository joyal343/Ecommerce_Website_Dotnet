from langchain_ollama import ChatOllama
from langchain_core.prompts import ChatPromptTemplate


query = "what is task decomposition ? "
context = "Hello"

print(context)
print("------------------")

template = """
Answer a question based on this context : {context}

Question : {query}
"""

prompt = ChatPromptTemplate.from_template(template)

llm = ChatOllama(
    model="llama3.2:3b",
    temperature=0,
)

chain = prompt | llm