class Object
   def using(resource)
     begin
     yield
     ensure
      resource.dispose
      end
   end
end
