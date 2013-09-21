class MyClass
def my_method(arg)
arg*3
end
end
obj=MyClass.new
puts obj.my_method(3)
puts obj.send(:my_method,3);


