class MyClass
def my_method(a,b)
a+yield(a,b)
end
end
o=MyClass.new
result=o.my_method(2,3) do |a,b|
  a+b
end
puts result;
